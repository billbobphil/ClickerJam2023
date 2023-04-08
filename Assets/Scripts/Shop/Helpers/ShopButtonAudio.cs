using UnityEngine;

namespace Shop.Helpers
{
    public class ShopButtonAudio : MonoBehaviour
    {
        public AudioSource hoverAudioSource;
        public AudioSource clickAudioSource;
        public AudioSource failAudioSource;
        public AudioSource purchaseAudioSource;
        
        public void PlayHoverSound()
        {
            hoverAudioSource.Play();
        }
        
        public void PlayClickSound()
        {
            clickAudioSource.Play();
        }
        
        public void PlayFailSound()
        {
            failAudioSource.Play();
        }
        
        public void PlayPurchaseSound()
        {
            purchaseAudioSource.Play();
        }
    }
}
