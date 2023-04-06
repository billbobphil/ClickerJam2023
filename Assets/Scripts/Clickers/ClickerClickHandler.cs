using System;
using System.Collections;
using Banks;
using UnityEngine;

namespace Clickers
{
    public class ClickerClickHandler : MonoBehaviour
    {
        public Clicker clicker;
        public float baseScale = 1f;
        public float expandScale = 1f;
        public bool isCriticalClicker = false;
        private Camera mainCamera;

        private void Awake()
        {
            transform.localScale = new Vector3(baseScale, baseScale, 1);
            mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>();
        }
        
        private void OnMouseDown()
        {
            Vector3 mousePosition = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePosition = new Vector3(mousePosition.x, mousePosition.y, 0);
            clicker.StealMoney(isCriticalClicker, mousePosition);
            StartCoroutine(ExpandClicker());
        }
        
        private IEnumerator ExpandClicker()
        {
            transform.localScale = new Vector3(expandScale, expandScale, 1);
            yield return new WaitForSeconds(0.05f);
            transform.localScale = new Vector3(baseScale, baseScale, 1);
        }
    }
}
