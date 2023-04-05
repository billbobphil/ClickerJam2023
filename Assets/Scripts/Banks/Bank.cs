using Player;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Banks
{
    public class Bank : MonoBehaviour
    {
        public delegate void MoneyStolen(ulong amountStolen);
        public static event MoneyStolen OnMoneyStolen;
        
        public TextMeshPro bankNameText;
        public TextMeshPro moneyText;
        public long startingMoney = 0;
        public long moneyRemaining = 0;
        public bool isBankrupt = false;
        private int _crewMembersAtBank = 0;
        public TextMeshPro crewMembersAtBankText;
        private Attributes _playerAttributes;

        private void Awake()
        {
            moneyRemaining = startingMoney;
            UpdateMoneyText();
            bankNameText.text = "<Cool Name> Bank";
            _playerAttributes = GameObject.FindWithTag("Player").GetComponent<Attributes>();
        }
        
        public void AddCrewMember()
        {
            _crewMembersAtBank++;
            UpdateCrewMembersAtBankText();
        }
        
        public void RemoveCrewMember()
        {
            _crewMembersAtBank--;
            UpdateCrewMembersAtBankText();
        }
        
        private void UpdateCrewMembersAtBankText()
        {
            crewMembersAtBankText.text = $"{_crewMembersAtBank}";
        }
        
        public long StealMoney(long amountToSteal)
        {
            if (isBankrupt)
            {
                return 0;
            }
            
            if (Random.Range(0f, 100f) > _playerAttributes.failHeistChance - _playerAttributes.heistFailReduction)
            {
                // Debug.Log("Stole Money!");
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
                OnMoneyStolen?.Invoke((ulong)amountToSteal);
                return amountToSteal;
            }
            else
            {
                // Debug.Log("COPS GOTCHA!");
                //TODO: lose some money?
                return -1;
            }
        }
        
        private void UpdateMoneyText()
        {
            moneyText.text = $"${moneyRemaining:n0}";
        }
    }
}
