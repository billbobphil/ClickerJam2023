namespace Shop.Upgrades
{
    public abstract class Upgrade
    {
        public ulong cost;

        public abstract void ApplyUpgrade();
    }
}