using Crew;
using Shop.Upgrades;
using TMPro;

namespace Shop.UpgradeCategories
{
    public class CrewUpgradeCategory : UpgradeCategory
    {
        public CrewMember crewMemberPrefab;
        public TextMeshProUGUI newCrewMemberCostText;
        public TextMeshProUGUI crewTrainingCostText;
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
                TrackDescription = "New crew members can be assigned to banks and will steal automatically."
            };
            
            AddCrewMemberUpgrade upgradeOne = new()
            {
                cost = 100,
                CrewMemberPrefab = crewMemberPrefab
            };
            addCrewMemberTrack.Upgrades.Add(upgradeOne);
            
            AddCrewMemberUpgrade upgradeTwo = new()
            {
                cost = 10000,
                CrewMemberPrefab = crewMemberPrefab
            };
            addCrewMemberTrack.Upgrades.Add(upgradeTwo);
            
            AddCrewMemberUpgrade upgradeThree = new()
            {
                cost = 1000000,
                CrewMemberPrefab = crewMemberPrefab
            };
            addCrewMemberTrack.Upgrades.Add(upgradeThree);
            
            AddCrewMemberUpgrade upgradeFour = new()
            {
                cost = 10000000,
                CrewMemberPrefab = crewMemberPrefab
            };
            addCrewMemberTrack.Upgrades.Add(upgradeFour);
            
            AddCrewMemberUpgrade upgradeFive = new()
            {
                cost = 100000000,
                CrewMemberPrefab = crewMemberPrefab
            };
            addCrewMemberTrack.Upgrades.Add(upgradeFive);
            
            AddCrewMemberUpgrade upgradeSix = new()
            {
                cost = 1000000000,
                CrewMemberPrefab = crewMemberPrefab
            };
            addCrewMemberTrack.Upgrades.Add(upgradeSix);
            
            AddCrewMemberUpgrade upgradeSeven = new()
            {
                cost = 10000000000,
                CrewMemberPrefab = crewMemberPrefab
            };
            addCrewMemberTrack.Upgrades.Add(upgradeSeven);
            
            return addCrewMemberTrack;
        }

        private UpgradeTrack BuildCrewTrainingTrack()
        {
            UpgradeTrack crewTrainingTrack = new()
            {
                TrackName = "Crew Training",
                TrackDescription = "Crew members will steal more often."
            };
            
            CrewTrainingUpgrade upgradeOne = new()
            {
                cost = 100,
                TimeBetweenSteals = 4
            };
            crewTrainingTrack.Upgrades.Add(upgradeOne);
            
            CrewTrainingUpgrade upgradeTwo = new()
            {
                cost = 10000,
                TimeBetweenSteals = 3
            };
            crewTrainingTrack.Upgrades.Add(upgradeTwo);
            
            CrewTrainingUpgrade upgradeThree = new()
            {
                cost = 1000000,
                TimeBetweenSteals = 2
            };
            crewTrainingTrack.Upgrades.Add(upgradeThree);
            
            CrewTrainingUpgrade upgradeFour = new()
            {
                cost = 10000000,
                TimeBetweenSteals = 1
            };
            crewTrainingTrack.Upgrades.Add(upgradeFour);
            
            CrewTrainingUpgrade upgradeFive = new()
            {
                cost = 100000000,
                TimeBetweenSteals = 0.5f
            };
            crewTrainingTrack.Upgrades.Add(upgradeFive);
            
            return crewTrainingTrack;
        }

        public override void UpdateUpgradeCostText()
        {
            newCrewMemberCostText.text = UpgradeTracks[0].CurrentLevel >= UpgradeTracks[0].Upgrades.Count ? "MAX" 
                : $"${UpgradeTracks[0].Upgrades[UpgradeTracks[0].CurrentLevel].cost.ToString()}";

            crewTrainingCostText.text = UpgradeTracks[1].CurrentLevel >= UpgradeTracks[1].Upgrades.Count ? "MAX" 
                : $"${UpgradeTracks[1].Upgrades[UpgradeTracks[1].CurrentLevel].cost.ToString()}";
        }
    }
}