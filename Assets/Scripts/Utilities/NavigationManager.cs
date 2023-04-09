using UnityEngine;
using UnityEngine.SceneManagement;

namespace Utilities
{
    public class NavigationManager : MonoBehaviour
    {
        public void GoToMenu()
        {
            SceneManager.LoadScene(0);
        }

        public void GoToGame()
        {
            SceneManager.LoadScene(1);
        }

        public void GoToCredits()
        {
            SceneManager.LoadScene(2);
        }
    }
}
