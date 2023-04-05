using Crew;
using Shop.Upgrades;
using TMPro;

namespace Shop.UpgradeCategories
{
    public class CrewUpgradeCategory : UpgradeCategory
    {
        public CrewMember crewMemberPrefab;
        public TextMeshProUGUI newCrewMemberCostText;
        public TextMeshProUGUI newCrewUpgradeNameText;
        public TextMeshProUGUI crewTrainingCostText;
        public TextMeshProUGUI crewTrainingUpgradeNameText;
        private void Start()
        {
            UpgradeTracks.Add(0, BuildNewCrewMemberTrack());
            UpgradeTracks.Add(1, BuildCrewTrainingTrack());
        }

        private UpgradeTrack BuildNewCrewMemberTrack()
        {
            UpgradeTrack addCrewMemberTrack = new()
            {
                TrackName = "New Crew Member",
                GetTrackDescription = GetTrackDescriptionForCrewMembers,
                CostText = newCrewMemberCostText,
                UpgradeNameText = newCrewUpgradeNameText
            };
            
            AddCrewMemberUpgrade upgradeOne = new()
            {
                Cost = 100,
                CrewMemberPrefab = crewMemberPrefab,
                UpgradeName = "New Guy 1"
            };
            addCrewMemberTrack.Upgrades.Add(upgradeOne);
            
            AddCrewMemberUpgrade upgradeTwo = new()
            {
                Cost = 10000,
                CrewMemberPrefab = crewMemberPrefab,
                UpgradeName = "New Guy 2"
            };
            addCrewMemberTrack.Upgrades.Add(upgradeTwo);
            
            AddCrewMemberUpgrade upgradeThree = new()
            {
                Cost = 1000000,
                CrewMemberPrefab = crewMemberPrefab,
                UpgradeName = "New Guy 3"
            };
            addCrewMemberTrack.Upgrades.Add(upgradeThree);
            
            AddCrewMemberUpgrade upgradeFour = new()
            {
                Cost = 10000000,
                CrewMemberPrefab = crewMemberPrefab,
                UpgradeName = "New Guy 4"
            };
            addCrewMemberTrack.Upgrades.Add(upgradeFour);
            
            AddCrewMemberUpgrade upgradeFive = new()
            {
                Cost = 100000000,
                CrewMemberPrefab = crewMemberPrefab,
                UpgradeName = "New Guy 5"
            };
            addCrewMemberTrack.Upgrades.Add(upgradeFive);
            
            AddCrewMemberUpgrade upgradeSix = new()
            {
                Cost = 1000000000,
                CrewMemberPrefab = crewMemberPrefab,
                UpgradeName = "New Guy 6"
            };
            addCrewMemberTrack.Upgrades.Add(upgradeSix);
            
            AddCrewMemberUpgrade upgradeSeven = new()
            {
                Cost = 10000000000,
                CrewMemberPrefab = crewMemberPrefab,
                UpgradeName = "New Guy 7"
            };
            addCrewMemberTrack.Upgrades.Add(upgradeSeven);
            
            return addCrewMemberTrack;
        }

        private UpgradeTrack BuildCrewTrainingTrack()
        {
            UpgradeTrack crewTrainingTrack = new()
            {
                TrackName = "Crew Training",
                GetTrackDescription = GetTrackDescriptionForCrewTraining,
                CostText = crewTrainingCostText,
                UpgradeNameText = crewTrainingUpgradeNameText
            };
            
            CrewTrainingUpgrade upgradeOne = new()
            {
                Cost = 100,
                TimeBetweenSteals = 4,
                UpgradeName = "Sleight of Hand"
            };
            crewTrainingTrack.Upgrades.Add(upgradeOne);
            
            CrewTrainingUpgrade upgradeTwo = new()
            {
                Cost = 10000,
                TimeBetweenSteals = 3,
                UpgradeName = "Lock Picking"
            };
            crewTrainingTrack.Upgrades.Add(upgradeTwo);
            
            CrewTrainingUpgrade upgradeThree = new()
            {
                Cost = 1000000,
                TimeBetweenSteals = 2,
                UpgradeName = "Safe Cracking"
            };
            crewTrainingTrack.Upgrades.Add(upgradeThree);
            
            CrewTrainingUpgrade upgradeFour = new()
            {
                Cost = 10000000,
                TimeBetweenSteals = 1,
                UpgradeName = "Burglary"
            };
            crewTrainingTrack.Upgrades.Add(upgradeFour);
            
            CrewTrainingUpgrade upgradeFive = new()
            {
                Cost = 100000000,
                TimeBetweenSteals = 0.5f,
                UpgradeName = "Master Thief"
            };
            crewTrainingTrack.Upgrades.Add(upgradeFive);
            
            return crewTrainingTrack;
        }

        private string GetTrackDescriptionForCrewMembers()
        {
            string baseMessage = "New crew members can be assigned to banks and will steal automatically.";
            string effect = "Effect: Add one new crew member";
            Upgrade upgrade = UpgradeTracks[0].Upgrades[UpgradeTracks[0].CurrentLevel];
            string cost = $"Cost: {upgrade.Cost}";
            
            return baseMessage + "\n\n" + effect + "\n\n" + cost;
        }

        private string GetTrackDescriptionForCrewTraining()
        {
            string baseMessage = "Crew members will steal more often.";
            return "TBD";
        }
    }
}