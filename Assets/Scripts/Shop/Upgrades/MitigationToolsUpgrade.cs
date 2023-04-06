namespace Shop.Upgrades
{
    public class MitigationToolsUpgrade : Upgrade
    {
        public float newHeistFailReduction;
        public override void ApplyUpgrade()
        {
            attributes.heistFailReduction = newHeistFailReduction;
        }
    }
}