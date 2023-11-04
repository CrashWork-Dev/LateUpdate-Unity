using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Menu.MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        private bool toInGame;

        public static void Switch2InGameMenu(bool ts)
        {
            if (ts) SceneManager.LoadScene("InGame");
        }

        private void Update()
        {
            Switch2InGameMenu(toInGame);
        }
    }
}