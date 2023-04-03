using System.Collections;
using Banks;
using UnityEngine;

namespace Crew
{
    public class CrewMember : MonoBehaviour
    {
        public Bank bank;
        
        //upgradeable? - sourced from an upgrade manager?
        public float timeBetweenSteals = 5f;

        public void StartStealing()
        {
            StartCoroutine(StealMoney());
        }
        
        public IEnumerator StealMoney()
        {
            for (;;)
            {
                yield return new WaitForSecondsRealtime(timeBetweenSteals);
                Debug.Log("Crew member stole");
                bank.StealMoney(1);    
            }
        }

        public void MoveToBank(Bank newBank)
        {
            bank = newBank;
            StartStealing();
        }
    }
}