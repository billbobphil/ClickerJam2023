using Shop.Upgrades;
using TMPro;

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
                Cost = 100,
                newMinTimeBetweenSpawns = 10,
                newMaxTimeBetweenSpawns = 20,
                UpgradeName = "Planning 1"
            };
            
            planningTrack.Upgrades.Add(upgradeOne);
            
            PlanningUpgrade upgradeTwo = new()
            {
                Cost = 10000,
                newMinTimeBetweenSpawns = 5,
                newMaxTimeBetweenSpawns = 10,
                UpgradeName = "Planning 2"
            };
            
            planningTrack.Upgrades.Add(upgradeTwo);
            
            PlanningUpgrade upgradeThree = new()
            {
                Cost = 1000000,
                newMinTimeBetweenSpawns = 2,
                newMaxTimeBetweenSpawns = 5,
                UpgradeName = "Planning 3"
            };
            
            planningTrack.Upgrades.Add(upgradeThree);
            
            PlanningUpgrade upgradeFour = new()
            {
                Cost = 10000000,
                newMinTimeBetweenSpawns = 1,
                newMaxTimeBetweenSpawns = 2,
                UpgradeName = "Planning 4"
            };
            
            planningTrack.Upgrades.Add(upgradeFour);
            
            PlanningUpgrade upgradeFive = new()
            {
                Cost = 1000000000,
                newMinTimeBetweenSpawns = 0.5f,
                newMaxTimeBetweenSpawns = 1,
                UpgradeName = "Planning 5"
            };
            
            planningTrack.Upgrades.Add(upgradeFive);
            
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
                Cost = 100,
                newCriticalClickModifier = 20,
                UpgradeName = "Practice 1"
            };
            
            practiceTrack.Upgrades.Add(upgradeOne);
            
            PracticeUpgrade upgradeTwo = new()
            {
                Cost = 10000,
                newCriticalClickModifier = 50,
                UpgradeName = "Practice 2"
            };
            
            practiceTrack.Upgrades.Add(upgradeTwo);
            
            PracticeUpgrade upgradeThree = new()
            {
                Cost = 1000000,
                newCriticalClickModifier = 100,
                UpgradeName = "Practice 3"
            };
            
            practiceTrack.Upgrades.Add(upgradeThree);
            
            PracticeUpgrade upgradeFour = new()
            {
                Cost = 10000000,
                newCriticalClickModifier = 1000,
                UpgradeName = "Practice 4"
            };
            
            practiceTrack.Upgrades.Add(upgradeFour);
            
            PracticeUpgrade upgradeFive = new()
            {
                Cost = 1000000000,
                newCriticalClickModifier = 10000,
                UpgradeName = "Practice 5"
            };
            
            practiceTrack.Upgrades.Add(upgradeFive);
            
            return practiceTrack;
        }
        
        private string GetTrackDescriptionForPlanning()
        {
            string baseMessage = "Better planning increases the frequency that critical opportunities will appear.";
            
            Upgrade upgrade = UpgradeTracks[0].Upgrades[UpgradeTracks[0].CurrentLevel];
            string effect = $"Effect: minimum time between critical opportunities becomes {((PlanningUpgrade)upgrade).newMinTimeBetweenSpawns} seconds, and the maximum time between critical opportunities becomes {((PlanningUpgrade)upgrade).newMaxTimeBetweenSpawns} seconds.";
            string cost = $"Cost: ${upgrade.Cost}";
            string name = $"{upgrade.UpgradeName}";
            
            return name + "\n\n" + baseMessage  + "\n\n" + effect + "\n\n" + cost;
        }
        
        private string GetTrackDescriptionForPractice()
        {
            string baseMessage = "Practice makes perfect. The more you practice, the more effective your critical opportunities will be.";
            
            Upgrade upgrade = UpgradeTracks[1].Upgrades[UpgradeTracks[1].CurrentLevel];
            string effect = $"Effect: critical opportunities now multiply your earnings by {((PracticeUpgrade)upgrade).newCriticalClickModifier}.";
            string cost = $"Cost: ${upgrade.Cost}";
            string name = $"{upgrade.UpgradeName}";
            
            return name + "\n\n" + baseMessage  + "\n\n" + effect + "\n\n" + cost;
        }
    }
}