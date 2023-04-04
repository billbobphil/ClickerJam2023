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
        
        private void Awake()
        {
            for (int i = 0; i < AscensionLevel + 1; i++)
            {
                //TODO: will need scaling and spawning logic to be able to fit multiple banks.
                Bank createdBank = Instantiate(bankPrefab, bankSpawnPoint.position, Quaternion.identity);
                Clicker createdClicker = Instantiate(clicker, clickerSpawnPoint.position, Quaternion.identity);
                createdClicker.bank = createdBank;
                registeredBanks.Add(createdBank);
            }
            
            timer.StartTimer();
        }

        private void OnEnable()
        {
            Bank.OnMoneyStolen += OnMoneyStolen;
        }
        
        private void OnDisable()
        {
            Bank.OnMoneyStolen -= OnMoneyStolen;
        }
        
        private void OnMoneyStolen(long amountStolen)
        {
            bool allBankrupt = registeredBanks.All(bank => bank.isBankrupt);
            
            if (allBankrupt)
            {
                Debug.Log("All banks are bankrupt! - Victory (Ascension)");
                //TODO: create prestige/end-game routine
            }
        }
    }
}
