namespace Shop.Upgrades
{
    public class GunUpgrade : Upgrade
    {
        public int amountToIncreaseBy;
        public override void ApplyUpgrade()
        {
            attributes.IncreaseIntimidationLevel(amountToIncreaseBy);
        }
    }
}