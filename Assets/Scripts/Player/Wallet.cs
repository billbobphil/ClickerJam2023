using Banks;
using TMPro;
using UnityEngine;

namespace Player
{
    public class Wallet : MonoBehaviour
    {
        public ulong money = 0;
        public TextMeshProUGUI moneyText;

        private void OnEnable()
        {
             Bank.OnMoneyStolen += AddMoney;
        }
        
        private void OnDisable()
        {
            Bank.OnMoneyStolen -= AddMoney;
        }
        
        private void Awake()
        {
            UpdateMoneyRemainingText();
        }

        public void AddMoney(long amountToAdd)
        {
            money += (ulong)amountToAdd;
            UpdateMoneyRemainingText();
        }
        
        public void RemoveMoney(long amountToRemove)
        {
            money -= (ulong)amountToRemove;
            UpdateMoneyRemainingText();
        }

        private void UpdateMoneyRemainingText()
        {
            moneyText.text = $"${money:n0}";
        }
    }
}
