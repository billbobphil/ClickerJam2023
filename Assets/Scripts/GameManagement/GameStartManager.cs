using Banks;
using Clickers;
using UnityEngine;

namespace GameManagement
{
    public class GameStartManager : MonoBehaviour
    {
        public Bank bankPrefab;
        public ClickerInteractionHandler clickerPrefab;
        public Transform bankSpawnPoint;
        public Transform clickerSpawnPoint;
        
        
        private void Awake()
        {
            Bank createdBank = Instantiate(bankPrefab, bankSpawnPoint.position, Quaternion.identity);
            ClickerInteractionHandler createdClicker = Instantiate(clickerPrefab, clickerSpawnPoint.position, Quaternion.identity);
            createdClicker.bank = createdBank;
        }
    }
}
