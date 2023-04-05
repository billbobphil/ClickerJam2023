using System.Collections.Generic;
using UnityEngine;

namespace Shop.UpgradeCategories
{
    public abstract class UpgradeCategory : MonoBehaviour
    {
        public string categoryName;
        public string description;
        public int id;
        public readonly Dictionary<int, UpgradeTrack> UpgradeTracks = new();
        public GameObject upgradePanel;

        public void Awake()
        {
            upgradePanel.SetActive(false);
        }

        public void UpdateUpgradeCostAndNameText()
        {
            foreach(KeyValuePair<int, UpgradeTrack> track in UpgradeTracks)
            {
                track.Value.CostText.text = track.Value.CurrentLevel >= track.Value.Upgrades.Count ? "MAX" 
                    : $"${track.Value.Upgrades[track.Value.CurrentLevel].Cost.ToString()}";

                track.Value.UpgradeNameText.text = track.Value.CurrentLevel >= track.Value.Upgrades.Count ? "MAX" 
                    : $"{track.Value.Upgrades[track.Value.CurrentLevel].UpgradeName}";
            }
        }
    }
}