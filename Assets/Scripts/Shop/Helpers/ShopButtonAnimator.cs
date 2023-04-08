using UnityEngine;

namespace Shop.Helpers
{
    public class ShopButtonAnimator : MonoBehaviour
    {
        public void ExpandButton()
        {
            transform.localScale += new Vector3(.1f, .1f, 0f);
        }
        
        public void ShrinkButton()
        {
            transform.localScale -= new Vector3(.1f, .1f, 0f);
        }
    }
}