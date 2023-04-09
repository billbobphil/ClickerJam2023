using System.Collections.Generic;
using System.Linq;
using Banks;
using Clickers;
using UnityEngine;
using Utilities;

namespace GameManagement
{
    public class GameStartManager : MonoBehaviour
    {
        public static int AscensionLevel = 0;
        public Bank bankPrefab;
        public Clicker clicker;
        public Transform bankSpawnPoint;
        public Transform clickerSpawnPoint;
        public List<Bank> registeredBanks = new();
        public Timer timer;
        public Timer victoryTimer;
        public GameObject victoryPanel;
        
        private void Awake()
        {
            for (int i = 0; i < AscensionLevel + 1; i++)
            {
                Bank createdBank = Instantiate(bankPrefab, bankSpawnPoint.position, Quaternion.identity);
                Clicker createdClicker = Instantiate(clicker, clickerSpawnPoint.position, Quaternion.identity);
                createdClicker.bank = createdBank;
                registeredBanks.Add(createdBank);
            }
            
            timer.StartTimer();
            victoryPanel.SetActive(false);
        }

        private void OnEnable()
        {
            Bank.OnMoneyStolen += OnMoneyStolen;
        }
        
        private void OnDisable()
        {
            Bank.OnMoneyStolen -= OnMoneyStolen;
        }
        
        private void OnMoneyStolen(ulong amountStolen)
        {
            bool allBankrupt = registeredBanks.All(bank => bank.isBankrupt);
            
            if (allBankrupt)
            {
                Debug.Log("All banks are bankrupt! - Victory (Ascension)");
                victoryPanel.SetActive(true);
                victoryTimer.SetTime(timer.GetTime());
                victoryTimer.UpdateTimerText();
            }
        }
    }
}
