using Crew;
using Player;
using Shop.Upgrades;
using TMPro;
using UnityEngine;
using Utilities;

namespace Shop.UpgradeCategories
{
    public class CrewUpgradeCategory : UpgradeCategory
    {
        public CrewMember crewMemberPrefab;
        public TextMeshProUGUI newCrewMemberCostText;
        public TextMeshProUGUI newCrewUpgradeNameText;
        public TextMeshProUGUI crewTrainingCostText;
        public TextMeshProUGUI crewTrainingUpgradeNameText;
        public int numberOfPossibleCrewMembers = 100;
        public TextMeshProUGUI crewMemberCountText;
        private CrewManager _playerCrew;

        private void Start()
        {
            _playerCrew = GameObject.FindWithTag("Player").GetComponent<CrewManager>();
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

            ulong costOfMember = 10;
            
            for(int i = 0; i < numberOfPossibleCrewMembers; i++)
            {
                AddCrewMemberUpgrade upgrade = new()
                {
                    Cost = costOfMember > 5000000000 ? 5000000000 : costOfMember,
                    CrewMemberPrefab = crewMemberPrefab,
                    UpgradeName = $"New Guy {i + 1}"
                };
                addCrewMemberTrack.Upgrades.Add(upgrade);

                int multiplier = i < 30 ? 2 : 1;
                costOfMember *= (ulong)multiplier;
            }

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
                Cost = 10,
                timeBetweenSteals = 9,
                UpgradeName = "Sleight of Hand"
            };
            crewTrainingTrack.Upgrades.Add(upgradeOne);
            
            CrewTrainingUpgrade upgradeTwo = new()
            {
                Cost = 100,
                timeBetweenSteals = 8,
                UpgradeName = "Lock Picking"
            };
            crewTrainingTrack.Upgrades.Add(upgradeTwo);
            
            CrewTrainingUpgrade upgradeThree = new()
            {
                Cost = 1000,
                timeBetweenSteals = 7,
                UpgradeName = "Safe Cracking"
            };
            crewTrainingTrack.Upgrades.Add(upgradeThree);
            
            CrewTrainingUpgrade upgradeFour = new()
            {
                Cost = 10000,
                timeBetweenSteals = 6,
                UpgradeName = "Burglar"
            };
            crewTrainingTrack.Upgrades.Add(upgradeFour);
            
            CrewTrainingUpgrade upgradeFive = new()
            {
                Cost = 100000,
                timeBetweenSteals = 5f,
                UpgradeName = "Trained Thief"
            };
            crewTrainingTrack.Upgrades.Add(upgradeFive);
            
            CrewTrainingUpgrade upgradeSix = new()
            {
                Cost = 1000000,
                timeBetweenSteals = 4f,
                UpgradeName = "Skilled Thief"
            };
            
            crewTrainingTrack.Upgrades.Add(upgradeSix);
            
            CrewTrainingUpgrade upgradeSeven = new()
            {
                Cost = 10000000,
                timeBetweenSteals = 3f,
                UpgradeName = "Expert Thief"
            };
            
            crewTrainingTrack.Upgrades.Add(upgradeSeven);
            
            CrewTrainingUpgrade upgradeEight = new()
            {
                Cost = 100000000,
                timeBetweenSteals = 2f,
                UpgradeName = "Brilliant Thief"
            };
            
            crewTrainingTrack.Upgrades.Add(upgradeEight);
            
            CrewTrainingUpgrade upgradeNine = new()
            {
                Cost = 1000000000,
                timeBetweenSteals = 1f,
                UpgradeName = "Master Thief"
            };
            
            crewTrainingTrack.Upgrades.Add(upgradeNine);
            
            CrewTrainingUpgrade upgradeTen = new()
            {
                Cost = 10000000000,
                timeBetweenSteals = 0.5f,
                UpgradeName = "Prolific Thief"
            };
            
            crewTrainingTrack.Upgrades.Add(upgradeTen);
            
            return crewTrainingTrack;
        }

        private string GetTrackDescriptionForCrewMembers()
        {
            string baseMessage = "New crew members can be assigned to banks and will steal automatically.";
            string effect = "Effect: Add one new crew member";
            Upgrade upgrade = UpgradeTracks[0].Upgrades[UpgradeTracks[0].CurrentLevel];
            string cost = $"Cost: {StaticHelpers.FormatMoney(upgrade.Cost)}";
            string name = $"{upgrade.UpgradeName}";
            
            return name + "\n\n" + baseMessage  + "\n\n" + effect + "\n\n" + cost;
        }

        private string GetTrackDescriptionForCrewTraining()
        {
            string baseMessage = "Crew members will steal more often.";
            Upgrade upgrade = UpgradeTracks[1].Upgrades[UpgradeTracks[1].CurrentLevel];
            string name = $"{upgrade.UpgradeName}";
            string cost = $"Cost: {StaticHelpers.FormatMoney(upgrade.Cost)}";
            string effect = $"Effect: Time between steals reduced to {((CrewTrainingUpgrade)upgrade).timeBetweenSteals} seconds";
            
            string message = name + "\n\n" + baseMessage + "\n\n" + effect + "\n\n" + cost;
            
            return message;
        }
    }
}