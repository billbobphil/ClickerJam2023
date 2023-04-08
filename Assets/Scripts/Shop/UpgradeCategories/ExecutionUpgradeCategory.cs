using Shop.Upgrades;
using TMPro;
using Utilities;

namespace Shop.UpgradeCategories
{
    public class ExecutionUpgradeCategory : UpgradeCategory
    {
        public TextMeshProUGUI planningCostText;
        public TextMeshProUGUI planningUpgradeNameText;
        public TextMeshProUGUI practiceCostText;
        public TextMeshProUGUI practiceUpgradeNameText;
        
        private void Start()
        {
            UpgradeTracks.Add(0, BuildPlanningTrack());
            UpgradeTracks.Add(1, BuildPracticeTrack());
        }

        private UpgradeTrack BuildPlanningTrack()
        {
            UpgradeTrack planningTrack = new()
            {
                TrackName = "Planning",
                GetTrackDescription = GetTrackDescriptionForPlanning,
                CostText = planningCostText,
                UpgradeNameText = planningUpgradeNameText
            };
            
            PlanningUpgrade upgradeOne = new()
            {
                Cost = 10,
                newMinTimeBetweenSpawns = 25,
                newMaxTimeBetweenSpawns = 35,
                UpgradeName = "Planning I"
            };
            
            planningTrack.Upgrades.Add(upgradeOne);
            
            PlanningUpgrade upgradeTwo = new()
            {
                Cost = 1000,
                newMinTimeBetweenSpawns = 20,
                newMaxTimeBetweenSpawns = 30,
                UpgradeName = "Planning II"
            };
            
            planningTrack.Upgrades.Add(upgradeTwo);
            
            PlanningUpgrade upgradeThree = new()
            {
                Cost = 10000,
                newMinTimeBetweenSpawns = 15,
                newMaxTimeBetweenSpawns = 25,
                UpgradeName = "Planning III"
            };
            
            planningTrack.Upgrades.Add(upgradeThree);
            
            PlanningUpgrade upgradeFour = new()
            {
                Cost = 500000,
                newMinTimeBetweenSpawns = 10,
                newMaxTimeBetweenSpawns = 20,
                UpgradeName = "Planning IV"
            };
            
            planningTrack.Upgrades.Add(upgradeFour);
            
            PlanningUpgrade upgradeFive = new()
            {
                Cost = 1000000,
                newMinTimeBetweenSpawns = 5,
                newMaxTimeBetweenSpawns = 15,
                UpgradeName = "Planning V"
            };
            
            planningTrack.Upgrades.Add(upgradeFive);
            
            PlanningUpgrade upgradeSix = new()
            {
                Cost = 10000000,
                newMinTimeBetweenSpawns = 1,
                newMaxTimeBetweenSpawns = 10,
                UpgradeName = "Planning VI"
            };
            
            planningTrack.Upgrades.Add(upgradeSix);
            
            PlanningUpgrade upgradeSeven = new()
            {
                Cost = 100000000,
                newMinTimeBetweenSpawns = 0.5f,
                newMaxTimeBetweenSpawns = 5,
                UpgradeName = "Planning VII"
            };
            
            planningTrack.Upgrades.Add(upgradeSeven);
            
            PlanningUpgrade upgradeEight = new()
            {
                Cost = 10000000000,
                newMinTimeBetweenSpawns = 0.5f,
                newMaxTimeBetweenSpawns = 1,
                UpgradeName = "Planning VIII"
            };
            
            planningTrack.Upgrades.Add(upgradeEight);
            
            return planningTrack;
        }
        
        private UpgradeTrack BuildPracticeTrack()
        {
            UpgradeTrack practiceTrack = new()
            {
                TrackName = "Practice",
                GetTrackDescription = GetTrackDescriptionForPractice,
                CostText = practiceCostText,
                UpgradeNameText = practiceUpgradeNameText
            };
            
            PracticeUpgrade upgradeOne = new()
            {
                Cost = 1000,
                newCriticalClickModifier = 4,
                UpgradeName = "Practice I"
            };
            
            practiceTrack.Upgrades.Add(upgradeOne);
            
            PracticeUpgrade upgradeTwo = new()
            {
                Cost = 100000,
                newCriticalClickModifier = 10,
                UpgradeName = "Practice II"
            };
            
            practiceTrack.Upgrades.Add(upgradeTwo);
            
            PracticeUpgrade upgradeThree = new()
            {
                Cost = 1000000,
                newCriticalClickModifier = 15,
                UpgradeName = "Practice III"
            };
            
            practiceTrack.Upgrades.Add(upgradeThree);
            
            PracticeUpgrade upgradeFour = new()
            {
                Cost = 10000000,
                newCriticalClickModifier = 20,
                UpgradeName = "Practice IV"
            };
            
            practiceTrack.Upgrades.Add(upgradeFour);
            
            PracticeUpgrade upgradeFive = new()
            {
                Cost = 100000000,
                newCriticalClickModifier = 25,
                UpgradeName = "Practice V"
            };
            
            practiceTrack.Upgrades.Add(upgradeFive);
            
            PracticeUpgrade upgradeSix = new()
            {
                Cost = 1000000000,
                newCriticalClickModifier = 30,
                UpgradeName = "Practice VI"
            };
            
            practiceTrack.Upgrades.Add(upgradeSix);
            
            PracticeUpgrade upgradeSeven = new()
            {
                Cost = 1000000000,
                newCriticalClickModifier = 35,
                UpgradeName = "Practice VII"
            };
            
            practiceTrack.Upgrades.Add(upgradeSeven);
            
            PracticeUpgrade upgradeEight = new()
            {
                Cost = 10000000000,
                newCriticalClickModifier = 40,
                UpgradeName = "Practice VIII"
            };
            
            practiceTrack.Upgrades.Add(upgradeEight);
            
            PracticeUpgrade upgradeNine = new()
            {
                Cost = 100000000000,
                newCriticalClickModifier = 50,
                UpgradeName = "Practice IX"
            };
            
            practiceTrack.Upgrades.Add(upgradeNine);

            return practiceTrack;
        }
        
        private string GetTrackDescriptionForPlanning()
        {
            string baseMessage = "Better planning increases the frequency that perfect timing opportunities will appear.";
            
            Upgrade upgrade = UpgradeTracks[0].Upgrades[UpgradeTracks[0].CurrentLevel];
            string effect = $"Effect: minimum time between perfect timing opportunities becomes {((PlanningUpgrade)upgrade).newMinTimeBetweenSpawns} seconds, and the maximum time between perfect timing opportunities becomes {((PlanningUpgrade)upgrade).newMaxTimeBetweenSpawns} seconds.";
            string cost = $"Cost: {StaticHelpers.FormatMoney(upgrade.Cost)}";
            string name = $"{upgrade.UpgradeName}";
            
            return name + "\n\n" + baseMessage  + "\n\n" + effect + "\n\n" + cost;
        }
        
        private string GetTrackDescriptionForPractice()
        {
            string baseMessage = "Practice makes perfect. The more you practice, the more effective your perfect timing opportunities will be.";
            
            Upgrade upgrade = UpgradeTracks[1].Upgrades[UpgradeTracks[1].CurrentLevel];
            string effect = $"Effect: perfect timing now multiplies your earnings by {((PracticeUpgrade)upgrade).newCriticalClickModifier}.";
            string cost = $"Cost: {StaticHelpers.FormatMoney(upgrade.Cost)}";
            string name = $"{upgrade.UpgradeName}";
            
            return name + "\n\n" + baseMessage  + "\n\n" + effect + "\n\n" + cost;
        }
    }
}