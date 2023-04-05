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

        private UpgradeCategory _currentCategory;
        
        private void Awake()
        {
            gameObject.SetActive(false);
        }
        
        public void CloseSubShopPanel()
        {
            _currentCategory = null;
            gameObject.SetActive(false);
        }

        public void ShowSubShopPanel(UpgradeCategory upgradeCategory)
        {
            if (upgradeCategory == _currentCategory)
            {
                gameObject.SetActive(false);
                _currentCategory = null;
                return;
            }
            
            titleText.text = upgradeCategory.categoryName;
            descriptionText.text = upgradeCategory.description;
            gameObject.SetActive(true);
            _currentCategory = upgradeCategory;
        }
    }
}