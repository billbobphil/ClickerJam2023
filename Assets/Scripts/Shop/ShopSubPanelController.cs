using Shop.UpgradeCategories;
using Shop.Upgrades;
using TMPro;
using UnityEngine;

namespace Shop
{
    public class ShopSubPanelController : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI titleText;
        [SerializeField]
        private TextMeshProUGUI descriptionText;
        public GameObject subShopCloseTriggerPanel;

        private void Awake()
        {
            gameObject.SetActive(false);
            subShopCloseTriggerPanel.SetActive(false);
        }
        
        public void CloseSubShopPanel()
        {
            gameObject.SetActive(false);
            subShopCloseTriggerPanel.SetActive(false);
        }

        public void ShowSubShopPanel(UpgradeCategory upgradeCategory)
        {
            titleText.text = upgradeCategory.categoryName;
            descriptionText.text = upgradeCategory.description;
            gameObject.SetActive(true);
            subShopCloseTriggerPanel.SetActive(true);
        }
    }
}