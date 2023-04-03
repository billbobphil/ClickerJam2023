using System.Collections;
using Banks;
using UnityEngine;

namespace Clickers
{
    public class Clicker : MonoBehaviour
    {
        public Bank bank;
        public ClickerClickHandler normalClickerHandler;
        public ClickerClickHandler criticalClickHandler;
        
        //upgradeable? - should be sourced from some sort of upgrade manager
        public int criticalClickMultiplier = 10;
        public int baseAmountToSteal = 1;
        public float criticalClickSpawnDelayMinimum = 5f;
        public float criticalClickSpawnDelayMaximum = 10f;
        public float criticalClickDuration = 5f;
        
        private void Awake()
        {
            criticalClickHandler.gameObject.SetActive(false);
        }
        
        private void Start()
        {
            StartCoroutine(ManageCriticalClicker());
        }
        
        private IEnumerator ManageCriticalClicker()
        {
            for (;;)
            {
                if (criticalClickHandler.isActiveAndEnabled)
                {
                    yield return new WaitForSeconds(1);
                    continue;
                }
                
                float randomDelay = Random.Range(criticalClickSpawnDelayMinimum, criticalClickSpawnDelayMaximum);
                yield return new WaitForSecondsRealtime(randomDelay);
                
                //Get position nested within the position of the parent clicker
                Bounds bounds = normalClickerHandler.GetComponent<BoxCollider2D>().bounds;
                float offsetX = Random.Range(-bounds.extents.x, bounds.extents.x);
                float offsetY = Random.Range(-bounds.extents.y, bounds.extents.y);
                criticalClickHandler.transform.position = bounds.center + new Vector3(offsetX, offsetY, 0);

                criticalClickHandler.gameObject.SetActive(true);
                yield return new WaitForSecondsRealtime(criticalClickDuration);
                criticalClickHandler.gameObject.SetActive(false);
            }
        }

        public void StealMoney(bool isCriticalClick)
        {
            long amountInJeopardy = isCriticalClick ? baseAmountToSteal * criticalClickMultiplier : baseAmountToSteal;
            bank.StealMoney(amountInJeopardy);
        }
    }
}