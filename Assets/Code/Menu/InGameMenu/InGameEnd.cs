using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Code.Menu.InGameMenu
{
    public class InGameEnd : MonoBehaviour
    {
        #region 环境

        private bool isRetry;
        [SerializeField] private Animator animator;
        [SerializeField] private GameObject endGame;
        [SerializeField] private Text text;
        [SerializeField] private AudioSource replay;
        [SerializeField] private GameObject mainMenu;
        private static readonly int Hp = Animator.StringToHash("Hp");
        private static readonly int Score = Animator.StringToHash("Score");

        #endregion

        #region 初始化

        private void Awake()
        {
            endGame.SetActive(false);
        }

        #endregion

        #region 处理

        private void Update()
        {
            if (animator.GetInteger(Hp) < 0 && !mainMenu.activeSelf)
            {
                CallMenu();
            }

            Retry(isRetry);
        }

        #endregion

        #region 行为

        private void Retry(bool rt)
        {
            if (!rt) return;
            replay.Play();
            SceneManager.LoadScene("InGame");
        }

        private void CallMenu()
        {
            Time.timeScale = 0;
            endGame.SetActive(true);
            text.text = "您的得分是: " + animator.GetInteger(Score);
            Cursor.visible = true;
        }

        #endregion
    }
}