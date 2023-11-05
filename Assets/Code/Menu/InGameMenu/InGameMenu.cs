using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Code.Menu.InGameMenu
{
    public class InGameMenu : MonoBehaviour
    {
        private bool toMainMenu;
        private GameObject inGame;
        private bool isMenuOpen;
        private void Awake()
        {
            inGame = GameObject.Find("InGameMenu");
            inGame.SetActive(isMenuOpen);
        }

        private void Update()
        {
            if (Keyboard.current.escapeKey.wasPressedThisFrame)
            {
                CallMenu();
            }
            Switch2MainMenu(toMainMenu);
        }

        private void CallMenu()
        {
            inGame.SetActive(!isMenuOpen);
            isMenuOpen = !isMenuOpen;
            Time.timeScale = isMenuOpen ? 0 : 1;
            Cursor.visible = isMenuOpen;
        }
        
        public static void Switch2MainMenu(bool ts)
        {
            if (!ts) return;
            Time.timeScale = 1;
            SceneManager.LoadScene("MainMenu");
        }
    }
}
