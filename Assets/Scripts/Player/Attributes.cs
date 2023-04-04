using UnityEngine;

namespace Player
{
    public class Attributes : MonoBehaviour
    {
        public int baseAmountToSteal = 1;
        public int intimidationLevel = 0;
        public int intimidationMultiplier = 10;
        public float timeBetweenCrewMemberSteals = 5f;
        
        public int criticalClickMultiplier = 10;
        public float criticalClickSpawnDelayMinimum = 5f;
        public float criticalClickSpawnDelayMaximum = 10f;
        public float criticalClickDuration = 5f;
        
        public float failHeistChance = 50f;
        public float heistFailReduction = 0f;

        public long GetAmountToSteal()
        {
            return baseAmountToSteal + intimidationLevel * intimidationMultiplier;
        }
    }
}