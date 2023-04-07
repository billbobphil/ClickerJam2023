using Player;
using UnityEngine;

namespace Shop.Upgrades
{
    public class CrewTrainingUpgrade : Upgrade
    {
        public float timeBetweenSteals;

        public override void ApplyUpgrade()
        {
            attributes.SetTimeBetweenCrewMemberSteals(timeBetweenSteals);
        }
    }
}