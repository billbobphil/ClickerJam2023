using System;
using System.Collections;
using Banks;
using UnityEngine;

namespace Clickers
{
    public class ClickerInteractionHandler : MonoBehaviour
    {
        public delegate void ClickerClicked();
        public static event ClickerClicked OnClickerClicked;
        
        public Bank bank;
        public float baseScale = 1f;
        public float expandScale = 1f;

        private void Awake()
        {
            transform.localScale = new Vector3(baseScale, baseScale, 1);
        }
        
        private void OnMouseDown()
        {
            Debug.Log("Clicker clicked!");
            StartCoroutine(ExpandClicker());
            OnClickerClicked?.Invoke();
            bank.StealMoney(1);
        }
        
        private IEnumerator ExpandClicker()
        {
            transform.localScale = new Vector3(expandScale, expandScale, 1);
            yield return new WaitForSeconds(0.05f);
            transform.localScale = new Vector3(baseScale, baseScale, 1);
        }
    }
}
