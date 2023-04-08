using Banks;
using TMPro;
using UnityEngine;
using Utilities;

namespace Player
{
    public class Wallet : MonoBehaviour
    {
        public ulong money = 0;
        public TextMeshProUGUI moneyText;
        public GameObject lostMoneyPrefab;
        public Transform lostMoneySpawnPoint;

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

        public void AddMoney(ulong amountToAdd)
        {
            money += amountToAdd;
            UpdateMoneyRemainingText();
        }
        
        public void RemoveMoney(ulong amountToRemove)
        {
            money -= amountToRemove;
            GameObject createdFloater = Instantiate(lostMoneyPrefab, lostMoneySpawnPoint);
            createdFloater.GetComponent<TextMeshPro>().text = StaticHelpers.FormatMoney(amountToRemove);
            UpdateMoneyRemainingText();
        }

        private void UpdateMoneyRemainingText()
        {
            moneyText.text = StaticHelpers.FormatMoney(money);
        }
    }
}
