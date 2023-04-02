using System;
using TMPro;
using UnityEngine;

namespace Banks
{
    public class Bank : MonoBehaviour
    {
        public delegate void MoneyStolen(long amountStolen);
        public static event MoneyStolen OnMoneyStolen;
        
        public TextMeshPro bankNameText;
        public TextMeshPro moneyText;
        public long startingMoney = 0;
        public long moneyRemaining = 0;

        private void Awake()
        {
            moneyRemaining = startingMoney;
            UpdateMoneyText();
            bankNameText.text = "<Cool Name> Bank";
        }

        public long StealMoney(long amountToSteal)
        {
            moneyRemaining -= amountToSteal;
            UpdateMoneyText();
            OnMoneyStolen?.Invoke(amountToSteal);
            return amountToSteal;
        }
        
        private void UpdateMoneyText()
        {
            moneyText.text = $"${moneyRemaining:n0}";
        }
    }
}
