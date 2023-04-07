namespace Shop.Upgrades
{
    public class MaskUpgrade : Upgrade
    {
        public int newMultiplier;
        public override void ApplyUpgrade()
        {
            attributes.SetIntimidationMultiplier(newMultiplier);
        }
    }
}