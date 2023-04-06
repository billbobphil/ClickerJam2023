using System.Collections.Generic;
using Player;
using Shop.UpgradeCategories;
using Shop.Upgrades;
using TMPro;
using UnityEngine;

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

        private void Awake()
        {
            _playerWallet = GameObject.FindWithTag("Player").GetComponent<Wallet>();
            tooltipPanel.SetActive(false);
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
                //TODO: implement UI messaging
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
                tooltipDescription.text = track.GetTrackDescription();
            }
            else
            {
                //TODO: messaging about cost
                Debug.Log("Cant afford this!");
            }
        }

        public void ShowTooltip(string categoryAndUpgradeTrack)
        {
            (int categoryId, int trackId) = ParseCategoryAndUpgradeTrack(categoryAndUpgradeTrack);
            
            UpgradeCategory category = upgradeCategories.Find(category => category.id == categoryId);
            UpgradeTrack track = category.UpgradeTracks[trackId];

            tooltipTitle.text = track.TrackName;
            tooltipDescription.text = track.GetTrackDescription();

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