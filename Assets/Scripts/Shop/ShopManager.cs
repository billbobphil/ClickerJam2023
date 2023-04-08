using System;
using System.Collections.Generic;
using Player;
using Shop.Helpers;
using Shop.UpgradeCategories;
using Shop.Upgrades;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utilities;

namespace Shop
{
    public class ShopManager : MonoBehaviour
    {
        public ShopSubPanelController shopSubPanelController;
        public List<UpgradeCategory> upgradeCategories;
        public GameObject tooltipPanel;
        public TextMeshProUGUI tooltipTitle;
        public TextMeshProUGUI tooltipDescription;
        private Wallet _playerWallet;
        public ShopButtonAudio shopButtonAudio;
        public Pulsate upgradeArrowPulsate;

        private void Awake()
        {
            _playerWallet = GameObject.FindWithTag("Player").GetComponent<Wallet>();
            tooltipPanel.SetActive(false);
        }

        private void LateUpdate()
        {
            bool canAffordAnyUpgrade = false;
            foreach(UpgradeCategory category in upgradeCategories)
            {
                bool canAffordUpgrade = false;
                foreach(KeyValuePair<int, UpgradeTrack> pair in category.UpgradeTracks)
                {
                    UpgradeTrack track = pair.Value;
                    
                    if (track.CurrentLevel >= track.Upgrades.Count)
                    {
                        continue;
                    }
                    
                    Upgrade upgrade = track.Upgrades[track.CurrentLevel];
                    ulong cost = upgrade.Cost;
                    if (_playerWallet.money >= cost)
                    {
                        canAffordUpgrade = true;
                        break;
                    }
                }

                if (canAffordUpgrade)
                {
                    category.shopButton.GetComponent<Image>().color = Color.yellow;
                    canAffordAnyUpgrade = true;
                }
                else
                {
                    category.shopButton.GetComponent<Image>().color = Color.white;
                }
            }

            upgradeArrowPulsate.enabled = canAffordAnyUpgrade;
        }

        public void OnUpgradeCategoryClick(int id)
        {
            CloseOtherUpgradePanels();
            shopSubPanelController.CloseSubShopPanel();
            UpgradeCategory category = upgradeCategories.Find(category => category.id == id);
            if (category != null)
            {
                shopSubPanelController.ShowSubShopPanel(category);
                category.upgradePanel.SetActive(true);
                category.UpdateUpgradeCostAndNameText();
            }   
        }

        private void CloseOtherUpgradePanels()
        {
            foreach (UpgradeCategory category in upgradeCategories)
            {
                if (category.upgradePanel != null)
                {
                    category.upgradePanel.SetActive(false);
                }
            }
        }

        public void BuyUpgrade(string categoryAndUpgradeTrack)
        {
            (int categoryId, int trackId) = ParseCategoryAndUpgradeTrack(categoryAndUpgradeTrack);
            //get the category
            UpgradeCategory category = upgradeCategories.Find(category => category.id == categoryId);
            //get the upgrade track
            UpgradeTrack track = category.UpgradeTracks[trackId];
            //get the cost of the next upgrade level

            if (track.CurrentLevel >= track.Upgrades.Count)
            {
                Debug.Log("At max upgrade level");
                shopButtonAudio.PlayFailSound();
                return;
            }
                
            Upgrade upgrade = track.Upgrades[track.CurrentLevel];
            ulong cost = upgrade.Cost;
            //if they can afford it
            if (_playerWallet.money >= cost)
            {
                Debug.Log("Buying upgrade");
                //deduct the cost
                _playerWallet.RemoveMoney(cost);
                //apply the upgrade
                upgrade.ApplyUpgrade();
                //increment the upgrade level
                track.CurrentLevel++;
                //Update cost text
                category.UpdateUpgradeCostAndNameText();
                
                if (track.CurrentLevel < track.Upgrades.Count)
                {
                    tooltipDescription.text = track.GetTrackDescription();    
                }
                else
                {
                    tooltipDescription.text = "Max level reached!";
                }
                
                shopButtonAudio.PlayPurchaseSound();
            }
            else
            {
                //TODO: messaging about cost
                Debug.Log("Cant afford this!");
                shopButtonAudio.PlayFailSound();
            }
        }

        public void ShowTooltip(string categoryAndUpgradeTrack)
        {
            (int categoryId, int trackId) = ParseCategoryAndUpgradeTrack(categoryAndUpgradeTrack);
            
            UpgradeCategory category = upgradeCategories.Find(category => category.id == categoryId);
            UpgradeTrack track = category.UpgradeTracks[trackId];

            tooltipTitle.text = track.TrackName;
            
            if (track.CurrentLevel < track.Upgrades.Count)
            {
                tooltipDescription.text = track.GetTrackDescription();
            }
            else
            {
                tooltipDescription.text = "Max level reached!";
            }

            tooltipPanel.SetActive(true);
        }

        public void HideTooltip()
        {
            tooltipPanel.SetActive(false);
        }

        private (int categoryId, int upgradeTrackId) ParseCategoryAndUpgradeTrack(string categoryAndUpgradeTrack)
        {
            string[] parts = categoryAndUpgradeTrack.Split("#!#");
            int categoryId = int.Parse(parts[0]);
            int trackId = int.Parse(parts[1]);

            return (categoryId, trackId);
        }
    }
}