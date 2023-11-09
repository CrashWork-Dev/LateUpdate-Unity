using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Menu.MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        private bool toInGame;
        private bool isQuit;

        public static void Switch2InGameMenu(bool ts)
        {
            if (!ts) return;
            SceneManager.LoadScene("InGame");
        }

        public static void Quit(bool qt)
        {
            if (qt) Application.Quit();
        }

        private void Update()
        {
            Switch2InGameMenu(toInGame);
            Quit(isQuit);
        }
    }
}