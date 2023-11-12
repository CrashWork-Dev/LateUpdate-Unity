using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

namespace Code.Menu.InGameMenu
{
    public class InGameMenu : MonoBehaviour
    {
        #region 环境

        private bool toMainMenu;
        [SerializeField] private GameObject[] otherMenu;
        [SerializeField] private GameObject inGame;
        private bool isMenuOpen;

        #endregion

        #region 初始化

        private void Awake()
        {
            Time.timeScale = 1;
            Cursor.visible = false;
            inGame.SetActive(isMenuOpen);
        }

        #endregion

        #region 处理

        private void Update()
        {
            if (Keyboard.current.escapeKey.wasPressedThisFrame)
            {
                CallMenu();
            }

            Switch2MainMenu(toMainMenu);
        }

        #endregion

        #region 行为

        private void IsOtherMenuOpen()
        {
            foreach (var t in otherMenu)
            {
                if (t.activeSelf) t.SetActive(false);
            }
        }

        private void CallMenu()
        {
            IsOtherMenuOpen();
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

        #endregion
        
    }
}