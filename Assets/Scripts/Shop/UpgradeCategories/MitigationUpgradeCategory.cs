using Shop.Upgrades;
using TMPro;
using Utilities;

namespace Shop.UpgradeCategories
{
    public class MitigationUpgradeCategory : UpgradeCategory
    {
        public TextMeshProUGUI toolsCostText;
        public TextMeshProUGUI toolsUpgradeNameText;

        private void Start()
        {
            UpgradeTracks.Add(0, BuildToolsTrack());
        }

        private UpgradeTrack BuildToolsTrack()
        {
            UpgradeTrack toolsTrack = new()
            {
                TrackName = "Tools",
                GetTrackDescription = GetTrackDescriptionForTools,
                CostText = toolsCostText,
                UpgradeNameText = toolsUpgradeNameText
            };
            
            MitigationToolsUpgrade upgradeOne = new()
            {
                Cost = 100,
                newHeistFailReduction = 5f,
                UpgradeName = "Zip-ties"
            };
            
            toolsTrack.Upgrades.Add(upgradeOne);
            
            MitigationToolsUpgrade upgradeTwo = new()
            {
                Cost = 10000,
                newHeistFailReduction = 10f,
                UpgradeName = "Gags"
            };
            
            toolsTrack.Upgrades.Add(upgradeTwo);
            
            MitigationToolsUpgrade upgradeThree = new()
            {
                Cost = 25000,
                newHeistFailReduction = 15f,
                UpgradeName = "Cell Jammer"
            };
            
            toolsTrack.Upgrades.Add(upgradeThree);
            
            MitigationToolsUpgrade upgradeFour = new()
            {
                Cost = 50000,
                newHeistFailReduction = 20f,
                UpgradeName = "Vault Drills"
            };
            
            toolsTrack.Upgrades.Add(upgradeFour);
            
            MitigationToolsUpgrade upgradeFive = new()
            {
                Cost = 100000,
                newHeistFailReduction = 25f,
                UpgradeName = "Get-Away Van"
            };
            
            toolsTrack.Upgrades.Add(upgradeFive);
            
            MitigationToolsUpgrade upgradeSix = new()
            {
                Cost = 1000000,
                newHeistFailReduction = 30f,
                UpgradeName = "Charted Sailings"
            };
            
            toolsTrack.Upgrades.Add(upgradeSix);
            
            MitigationToolsUpgrade upgradeSeven = new()
            {
                Cost = 10000000,
                newHeistFailReduction = 35f,
                UpgradeName = "Helicopter"
            };
            
            toolsTrack.Upgrades.Add(upgradeSeven);
            
            MitigationToolsUpgrade upgradeEight = new()
            {
                Cost = 100000000,
                newHeistFailReduction = 40f,
                UpgradeName = "Private Jet"
            };
            
            toolsTrack.Upgrades.Add(upgradeEight);
            
            MitigationToolsUpgrade upgradeNine = new()
            {
                Cost = 1000000000,
                newHeistFailReduction = 45f,
                UpgradeName = "Time Machine"
            };
            
            toolsTrack.Upgrades.Add(upgradeNine);
            
            MitigationToolsUpgrade upgradeTen = new()
            {
                Cost = 10000000000,
                newHeistFailReduction = 50f,
                UpgradeName = "The One Ring"
            };
            
            toolsTrack.Upgrades.Add(upgradeTen);

            return toolsTrack;
        }
        
        private string GetTrackDescriptionForTools()
        {
            string baseMessage = "The various mitigation tools will help reduce the chance that you're caught by the police.";
            Upgrade upgrade = UpgradeTracks[0].Upgrades[UpgradeTracks[0].CurrentLevel];
            string name = $"{upgrade.UpgradeName}";
            string cost = $"Cost: {StaticHelpers.FormatMoney(upgrade.Cost)}";
            string effect = $"Effect: Chance of being caught by the cops reduced by {((MitigationToolsUpgrade)upgrade).newHeistFailReduction} percent";
            
            string message = name + "\n\n" + baseMessage + "\n\n" + effect + "\n\n" + cost;
            
            return message;
        }
    }
}