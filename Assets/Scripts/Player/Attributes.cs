using UnityEngine;

namespace Player
{
    public class Attributes : MonoBehaviour
    {
        public int baseAmountToSteal = 1; //used
        public int intimidationLevel = 0; //used
        public int intimidationMultiplier = 10; //used
        public float timeBetweenCrewMemberSteals = 10f; //used
        
        public int criticalClickMultiplier = 10; //used
        public float criticalClickSpawnDelayMinimum = 5f; //used
        public float criticalClickSpawnDelayMaximum = 10f; //used
        public float criticalClickDuration = 5f;
        
        public float failHeistChance = 50f;
        public float heistFailReduction = 0f;

        public long GetAmountToSteal()
        {
            return baseAmountToSteal + intimidationLevel * intimidationMultiplier;
        }
    }
}