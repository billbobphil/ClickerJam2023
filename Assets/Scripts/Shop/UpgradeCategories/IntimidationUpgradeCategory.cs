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
                Cost = 10,
                UpgradeName = "Water Pistols",
                amountToIncreaseBy = 2
            };
            
            GunUpgrade upgradeTwo = new()
            {
                Cost = 100,
                UpgradeName = "Cap Guns Hand Guns",
                amountToIncreaseBy = 8
            };
            
            GunUpgrade upgradeThree = new()
            {
                Cost = 1000,
                UpgradeName = "BB Guns Semi-Automatics",
                amountToIncreaseBy = 20
            };
            
            GunUpgrade upgradeFour = new()
            {
                Cost = 10000,
                UpgradeName = "Semi-Automatics",
                amountToIncreaseBy = 120
            };
            
            GunUpgrade upgradeFive = new()
            {
                Cost = 100000,
                UpgradeName = "Full-Automatics",
                amountToIncreaseBy = 150
            };

            GunUpgrade upgradeSix = new()
            {
                Cost = 1000000,
                UpgradeName =  "Military-Grade",
                amountToIncreaseBy = 300
            };
            
            GunUpgrade upgradeSeven = new()
            {
                Cost = 100000000,
                UpgradeName = "Heavy Artillery",
                amountToIncreaseBy = 900
            };
            
            GunUpgrade upgradeEight = new()
            {
                Cost = 1000000000,
                UpgradeName = "Nuclear Weapons",
                amountToIncreaseBy = 1500
            };
            
            GunUpgrade upgradeNine = new()
            {
                Cost = 10000000000,
                UpgradeName = "Alien Technology",
                amountToIncreaseBy = 3000
            };
            
            gunsTrack.Upgrades.Add(upgradeOne);
            gunsTrack.Upgrades.Add(upgradeTwo);
            gunsTrack.Upgrades.Add(upgradeThree);
            gunsTrack.Upgrades.Add(upgradeFour);
            gunsTrack.Upgrades.Add(upgradeFive);
            gunsTrack.Upgrades.Add(upgradeSix);
            gunsTrack.Upgrades.Add(upgradeSeven);
            gunsTrack.Upgrades.Add(upgradeEight);
            gunsTrack.Upgrades.Add(upgradeNine);
            
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
                Cost = 10,
                UpgradeName = "Medical Masks",
                newMultiplier = 2
            };
            
            MaskUpgrade upgradeTwo = new()
            {
                Cost = 1000,
                UpgradeName = "Ski Masks",
                newMultiplier = 5
            };
            
            MaskUpgrade upgradeThree = new()
            {
                Cost = 5000,
                UpgradeName = "Animal Masks",
                newMultiplier = 7
            };

            MaskUpgrade upgradeFour = new()
            {
                Cost = 25000,
                UpgradeName = "Hockey Masks",
                newMultiplier = 10
            };
            
            MaskUpgrade upgradeFive = new()
            {
                Cost = 100000,
                UpgradeName = "Clown Masks",
                newMultiplier = 15
            };
            
            MaskUpgrade upgradeSix = new()
            {
                Cost = 1000000,
                UpgradeName = "Gas Masks",
                newMultiplier = 25
            };
            
            MaskUpgrade upgradeSeven = new()
            {
                Cost = 10000000,
                UpgradeName = "Halloween Masks",
                newMultiplier = 35
            };
            
            MaskUpgrade upgradeEight = new()
            {
                Cost = 100000000,
                UpgradeName = "Metal Masks",
                newMultiplier = 50
            };
            
            MaskUpgrade upgradeNine = new()
            {
                Cost = 1000000000,
                UpgradeName = "Custom Masks",
                newMultiplier = 75
            };
            
            MaskUpgrade upgradeTen = new()
            {
                Cost = 10000000000,
                UpgradeName = "Prolific Masks",
                newMultiplier = 100
            };
            
            masksTrack.Upgrades.Add(upgradeOne);
            masksTrack.Upgrades.Add(upgradeTwo);
            masksTrack.Upgrades.Add(upgradeThree);
            masksTrack.Upgrades.Add(upgradeFour);
            masksTrack.Upgrades.Add(upgradeFive);
            masksTrack.Upgrades.Add(upgradeSix);
            masksTrack.Upgrades.Add(upgradeSeven);
            masksTrack.Upgrades.Add(upgradeEight);
            masksTrack.Upgrades.Add(upgradeNine);
            masksTrack.Upgrades.Add(upgradeTen);
            
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