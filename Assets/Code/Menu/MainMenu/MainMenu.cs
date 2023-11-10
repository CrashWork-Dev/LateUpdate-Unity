using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Code.Menu.MainMenu
{
    public class MainMenu : MonoBehaviour
    {
        private bool toInGame;
        private bool isQuit;
        private bool isMusicFinish;
        [SerializeField] private RawImage dlx;
        [SerializeField] private Button start;
        [SerializeField] private Button quit;
        public static void Switch2InGameMenu(bool ts)
        {
            if (!ts) return;
            SceneManager.LoadScene("Loading");
        }

        private void Awake()
        {
            dlx.gameObject.SetActive(false);
        }

        private void Start()
        {
            ButtonMoveUp();
            Invoke(nameof(FinishDx),8.35f);
        }

        private void ButtonMoveUp()
        {
            var transform1 = start.transform;
            var position1 = transform1.position;
            start.transform.position = Vector3.Lerp(position1,
                new Vector3(position1.x, position1.y + 8f, position1.z),0.4f);
            var transform2 = quit.transform;
            var position2 = transform2.position;
            quit.transform.position = Vector3.Lerp(position2,
                new Vector3(position2.x, position2.y - 8f, position2.z),0.4f);
            Invoke(nameof(ButtonMoveDown),0.4f);
        }

        private void ButtonMoveDown()
        {
            var transform1 = start.transform;
            var position1 = transform1.position;
            start.transform.position = Vector3.Lerp(position1,
                new Vector3(position1.x, position1.y - 8f, position1.z),0.4f);
            var transform2 = quit.transform;
            var position2 = transform2.position;
            quit.transform.position = Vector3.Lerp(position2,
                new Vector3(position2.x, position2.y + 8f, position2.z),0.4f);
            Invoke(nameof(ButtonMoveUp),0.4f);
        }
        private void FinishDx()
        {
            dlx.gameObject.SetActive(true);
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