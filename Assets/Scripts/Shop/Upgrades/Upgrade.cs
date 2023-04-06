using Player;
using UnityEngine;

namespace Shop.Upgrades
{
    public abstract class Upgrade
    {
        public ulong Cost;
        public string UpgradeName;
        protected readonly Attributes attributes;

        protected Upgrade()
        {
            attributes = GameObject.FindWithTag("Player").GetComponent<Attributes>();
        }

        public abstract void ApplyUpgrade();
    }
}