using System.Collections;
using Banks;
using Player;
using UnityEngine;

namespace Clickers
{
    public class Clicker : MonoBehaviour
    {
        public Bank bank;
        public ClickerClickHandler normalClickerHandler;
        public ClickerClickHandler criticalClickHandler;
        private Attributes _playerAttributes;

        private void Awake()
        {
            _playerAttributes = GameObject.FindWithTag("Player").GetComponent<Attributes>();
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
                
                float randomDelay = Random.Range(_playerAttributes.criticalClickSpawnDelayMinimum, _playerAttributes.criticalClickSpawnDelayMaximum);
                yield return new WaitForSecondsRealtime(randomDelay);
                
                //Get position nested within the position of the parent clicker
                Bounds bounds = normalClickerHandler.GetComponent<BoxCollider2D>().bounds;
                float offsetX = Random.Range(-bounds.extents.x, bounds.extents.x);
                float offsetY = Random.Range(-bounds.extents.y, bounds.extents.y);
                criticalClickHandler.transform.position = bounds.center + new Vector3(offsetX, offsetY, 0);

                criticalClickHandler.gameObject.SetActive(true);
                yield return new WaitForSecondsRealtime(_playerAttributes.criticalClickDuration);
                criticalClickHandler.gameObject.SetActive(false);
            }
        }

        public void StealMoney(bool isCriticalClick)
        {
            long intimidationAdjustedBase = _playerAttributes.GetAmountToSteal();
            long amountInJeopardy = isCriticalClick ? intimidationAdjustedBase * _playerAttributes.criticalClickMultiplier : intimidationAdjustedBase;
            bank.StealMoney(amountInJeopardy);
        }
    }
}