using System.Collections;
using Banks;
using Player;
using UnityEngine;

namespace Crew
{
    public class CrewMember : MonoBehaviour
    {
        public Bank bank;
        private Attributes _playerAttributes;
        
        private void Awake()
        {
            _playerAttributes = GameObject.FindWithTag("Player").GetComponent<Attributes>();
        }
        
        public void StartStealing()
        {
            StartCoroutine(nameof(StealMoney));
        }
        
        public IEnumerator StealMoney()
        {
            for (;;)
            {
                yield return new WaitForSecondsRealtime(_playerAttributes.timeBetweenCrewMemberSteals);
                // Debug.Log("Crew member stole");
                if (bank is not null)
                {
                    bank.StealMoney(_playerAttributes.GetAmountToSteal());
                }
            }
        }

        public void MoveToBank(Bank newBank)
        {
            bank = newBank;
            StartStealing();
        }

        public void RemoveFromBank()
        {
            bank = null;
            StopCoroutine(nameof(StealMoney));
        }
    }
}