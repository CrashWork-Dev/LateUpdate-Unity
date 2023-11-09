using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Code.Menu.InGameMenu
{
    public class InGameEnd : MonoBehaviour
    {
        private bool isRetry;
        [SerializeField] private Animator animator;
        [SerializeField] private GameObject endGame;
        [SerializeField] private Text text;
        private static readonly int Hp = Animator.StringToHash("Hp");
        private static readonly int Score = Animator.StringToHash("Score");

        private void Awake()
        {
            endGame.SetActive(false);
        }

        private static void Retry(bool rt)
        {
            if (!rt) return;
            SceneManager.LoadScene("InGame");
        }

        private void CallMenu()
        {
            Time.timeScale = 0;
            endGame.SetActive(true);
            text.text = "您的得分是: " + animator.GetInteger(Score);
            Cursor.visible = true;
        }

        private void Update()
        {
            if (animator.GetInteger(Hp) < 0)
            {
                CallMenu();
            }

            Retry(isRetry);
        }
    }
}