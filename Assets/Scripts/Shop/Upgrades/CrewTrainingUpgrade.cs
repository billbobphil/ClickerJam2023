using Player;
using UnityEngine;

namespace Shop.Upgrades
{
    public class CrewTrainingUpgrade : Upgrade
    {
        public float TimeBetweenSteals;
        private Attributes _attributes;
        
        public CrewTrainingUpgrade()
        {
            _attributes = GameObject.FindWithTag("Player").GetComponent<Attributes>();
        }

        public override void ApplyUpgrade()
        {
            _attributes.timeBetweenCrewMemberSteals = TimeBetweenSteals;
        }
    }
}