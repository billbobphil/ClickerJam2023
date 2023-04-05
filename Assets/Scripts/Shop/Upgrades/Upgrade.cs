namespace Shop.Upgrades
{
    public abstract class Upgrade
    {
        public ulong Cost;
        public string UpgradeName;

        public abstract void ApplyUpgrade();
    }
}