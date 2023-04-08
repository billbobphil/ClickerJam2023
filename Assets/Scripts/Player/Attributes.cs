using TMPro;
using UnityEngine;

namespace Player
{
    public class Attributes : MonoBehaviour
    {
        public int baseAmountToSteal = 1; //used
        public int intimidationLevel = 0; //used
        public int intimidationMultiplier = 1; //used
        public float timeBetweenCrewMemberSteals = 5f; //used
        
        public int criticalClickMultiplier = 2; //used
        public float criticalClickSpawnDelayMinimum = 20f; //used
        public float criticalClickSpawnDelayMaximum = 40f; //used
        public float criticalClickDuration = 5f;
        
        public float failHeistChance = 50f;
        public float heistFailReduction = 0f;
        
        public TextMeshProUGUI baseAmountToStealText;
        public TextMeshProUGUI intimidationLevelText;
        public TextMeshProUGUI intimidationMultiplierText;
        public TextMeshProUGUI totalTakeText;
        public TextMeshProUGUI criticalMultiplierText;
        public TextMeshProUGUI heistFailureChanceText;
        public TextMeshProUGUI timeBetweenCrewMemberStealsText;

        private void Start()
        {
            baseAmountToStealText.text = baseAmountToSteal.ToString();
            intimidationLevelText.text = intimidationLevel.ToString();
            intimidationMultiplierText.text = intimidationMultiplier.ToString();
            totalTakeText.text = GetAmountToSteal().ToString();
            criticalMultiplierText.text = criticalClickMultiplier.ToString();
            float heistFailChance = failHeistChance - heistFailReduction;
            heistFailureChanceText.text = $"{heistFailChance:n0}%";
            timeBetweenCrewMemberStealsText.text = timeBetweenCrewMemberSteals.ToString();
        }
        
        public long GetAmountToSteal()
        {
            return baseAmountToSteal + intimidationLevel * intimidationMultiplier;
        }

        public void IncreaseIntimidationLevel(int amountToIncreaseBy)
        {
            intimidationLevel += amountToIncreaseBy;
            intimidationLevelText.text = intimidationLevel.ToString();
            totalTakeText.text = GetAmountToSteal().ToString();
        }
        
        public void SetIntimidationMultiplier(int newMultiplier)
        {
            intimidationMultiplier = newMultiplier;
            intimidationMultiplierText.text = intimidationMultiplier.ToString();
            totalTakeText.text = GetAmountToSteal().ToString();
        }
        
        public void SetCriticalClickerModifier(int newModifier)
        {
            criticalClickMultiplier = newModifier;
            criticalMultiplierText.text = criticalClickMultiplier.ToString();
        }
        
        public void SetHeistFailReduction(float newReduction)
        {
            heistFailReduction = newReduction;
            float heistFailChance = failHeistChance - heistFailReduction;
            heistFailureChanceText.text = $"{heistFailChance:n0}%";
        }
        
        public void SetTimeBetweenCrewMemberSteals(float newTime)
        {
            timeBetweenCrewMemberSteals = newTime;
            timeBetweenCrewMemberStealsText.text = timeBetweenCrewMemberSteals.ToString();
        }
    }
}