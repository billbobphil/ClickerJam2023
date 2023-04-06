using Player;
using TMPro;
using UnityEngine;
using Utilities;
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
        public GameObject GotMoneyPrefab;
        public GameObject CaughtByCopsPrefab;

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
        
        public long StealMoney(long amountToSteal, Vector3 mousePosition = default)
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

                if (mousePosition != default)
                {
                    GameObject newObject = Instantiate(GotMoneyPrefab, mousePosition, Quaternion.identity);
                    newObject.GetComponent<TextMeshPro>().text = $"${amountToSteal:n0}";
                }
                
                return amountToSteal;
            }
            else
            {
                // Debug.Log("COPS GOTCHA!");
                if(mousePosition != default)
                {
                    Instantiate(CaughtByCopsPrefab, mousePosition, Quaternion.identity);
                }
                
                return -1;
            }
        }
        
        private void UpdateMoneyText()
        {
            moneyText.text = StaticHelpers.FormatMoney((ulong)moneyRemaining);
        }
    }
}
