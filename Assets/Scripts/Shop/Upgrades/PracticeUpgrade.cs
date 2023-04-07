namespace Shop.Upgrades
{
    public class PracticeUpgrade : Upgrade
    {
        public int newCriticalClickModifier;
        public override void ApplyUpgrade()
        {
            attributes.SetCriticalClickerModifier(newCriticalClickModifier);
        }
    }
}