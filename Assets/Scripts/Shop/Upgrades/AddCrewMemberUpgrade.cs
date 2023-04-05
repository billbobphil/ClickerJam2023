using Crew;
using Player;
using UnityEngine;

namespace Shop.Upgrades
{
    public class AddCrewMemberUpgrade : Upgrade
    {
        private readonly CrewManager _crewManager;
        public CrewMember CrewMemberPrefab;

        public AddCrewMemberUpgrade()
        {
            _crewManager = GameObject.FindWithTag("Player").GetComponent<CrewManager>();
        }
        
        public override void ApplyUpgrade()
        {
            CrewMember newMember = GameObject.Instantiate(CrewMemberPrefab);
            _crewManager.AddNewCrewMember(newMember);
        }
    }
}