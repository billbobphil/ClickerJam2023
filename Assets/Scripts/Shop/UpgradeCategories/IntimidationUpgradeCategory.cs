using Shop.Upgrades;
using TMPro;
using Utilities;

namespace Shop.UpgradeCategories
{
    public class IntimidationUpgradeCategory : UpgradeCategory
    {
        public TextMeshProUGUI gunsUpgradeCostText;
        public TextMeshProUGUI gunsUpgradeNameText;
        public TextMeshProUGUI masksUpgradeCostText;
        public TextMeshProUGUI masksUpgradeNameText;

        private void Start()
        {
            UpgradeTracks.Add(0, BuildGunsTrack());
            UpgradeTracks.Add(1, BuildMasksTrack());   
        }
        
        private UpgradeTrack BuildGunsTrack()
        {
            UpgradeTrack gunsTrack = new()
            {
                TrackName = "Guns",
                GetTrackDescription = GetTrackDescriptionForGuns,
                CostText = gunsUpgradeCostText,
                UpgradeNameText = gunsUpgradeNameText
            };
            
            GunUpgrade upgradeOne = new()
            {
                Cost = 100,
                UpgradeName = "Water Pistols",
                amountToIncreaseBy = 2
            };
            
            GunUpgrade upgradeTwo = new()
            {
                Cost = 10000,
                UpgradeName = "Hand Guns",
                amountToIncreaseBy = 10
            };
            
            GunUpgrade upgradeThree = new()
            {
                Cost = 1000000,
                UpgradeName = "Semi-Automatics",
                amountToIncreaseBy = 10
            };
            
            GunUpgrade upgradeFour = new()
            {
                Cost = 10000000,
                UpgradeName = "Automatics",
                amountToIncreaseBy = 10
            };
            
            GunUpgrade upgradeFive = new()
            {
                Cost = 1000000000,
                UpgradeName = "Heavy Artillery",
                amountToIncreaseBy = 100
            };
            
            gunsTrack.Upgrades.Add(upgradeOne);
            gunsTrack.Upgrades.Add(upgradeTwo);
            gunsTrack.Upgrades.Add(upgradeThree);
            gunsTrack.Upgrades.Add(upgradeFour);
            gunsTrack.Upgrades.Add(upgradeFive);
            
            return gunsTrack;
        }

        private UpgradeTrack BuildMasksTrack()
        {
            UpgradeTrack masksTrack = new()
            {
                TrackName = "Masks",
                GetTrackDescription = GetTrackDescriptionForMasks,
                CostText = masksUpgradeCostText,
                UpgradeNameText = masksUpgradeNameText
            };
            
            MaskUpgrade upgradeOne = new()
            {
                Cost = 100,
                UpgradeName = "Medical Masks",
                newMultiplier = 15
            };
            
            MaskUpgrade upgradeTwo = new()
            {
                Cost = 10000,
                UpgradeName = "Ski Masks",
                newMultiplier = 30
            };
            
            MaskUpgrade upgradeThree = new()
            {
                Cost = 1000000,
                UpgradeName = "Hockey Masks",
                newMultiplier = 50
            };
            
            MaskUpgrade upgradeFour = new()
            {
                Cost = 10000000,
                UpgradeName = "Clown Masks",
                newMultiplier = 100
            };
            
            MaskUpgrade upgradeFive = new()
            {
                Cost = 1000000000,
                UpgradeName = "Infamous Masks",
                newMultiplier = 1000
            };
            
            masksTrack.Upgrades.Add(upgradeOne);
            masksTrack.Upgrades.Add(upgradeTwo);
            masksTrack.Upgrades.Add(upgradeThree);
            masksTrack.Upgrades.Add(upgradeFour);
            masksTrack.Upgrades.Add(upgradeFive);
            
            return masksTrack;
        }

        private string GetTrackDescriptionForMasks()
        {
            string baseMessage = "Increase your intimidation multiplier.";
            Upgrade upgrade = UpgradeTracks[1].Upgrades[UpgradeTracks[1].CurrentLevel];
            string name = $"{upgrade.UpgradeName}";
            string cost = $"Cost: {StaticHelpers.FormatMoney(upgrade.Cost)}";
            string effect = $"Effect: Intimidation multiplier set to {((MaskUpgrade)upgrade).newMultiplier}";
            
            string message = name + "\n\n" + baseMessage + "\n\n" + effect + "\n\n" + cost;
            
            return message;
        }
        
        private string GetTrackDescriptionForGuns()
        {
            string baseMessage = "Increase your intimidation level.";
            Upgrade upgrade = UpgradeTracks[0].Upgrades[UpgradeTracks[0].CurrentLevel];
            string name = $"{upgrade.UpgradeName}";
            string cost = $"Cost: {StaticHelpers.FormatMoney(upgrade.Cost)}";
            string effect = $"Effect: Intimidation level increased by {((GunUpgrade)upgrade).amountToIncreaseBy} points";
            
            string message = name + "\n\n" + baseMessage + "\n\n" + effect + "\n\n" + cost;
            
            return message;
        }
    }
}