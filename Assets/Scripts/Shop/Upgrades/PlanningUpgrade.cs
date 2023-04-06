namespace Shop.Upgrades
{
    public class PlanningUpgrade : Upgrade
    {
        public float newMaxTimeBetweenSpawns;
        public float newMinTimeBetweenSpawns;
        public override void ApplyUpgrade()
        {
            attributes.criticalClickSpawnDelayMaximum = newMaxTimeBetweenSpawns;
            attributes.criticalClickSpawnDelayMinimum = newMinTimeBetweenSpawns;
        }
    }
}