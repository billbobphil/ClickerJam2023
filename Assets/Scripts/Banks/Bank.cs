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
        public bool isBankrupt = false;

        private void Awake()
        {
            moneyRemaining = startingMoney;
            UpdateMoneyText();
            bankNameText.text = "<Cool Name> Bank";
        }

        public long StealMoney(long amountToSteal)
        {
            if (isBankrupt)
            {
                return 0;
            }
            
            long actualAmountToSteal = amountToSteal;

            if (amountToSteal > moneyRemaining)
            {
                actualAmountToSteal = moneyRemaining;
            }

            moneyRemaining -= actualAmountToSteal;

            if (moneyRemaining <= 0)
            {
                moneyRemaining = 0;
                isBankrupt = true;
            }

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
