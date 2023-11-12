using UnityEngine;
using UnityEngine.SceneManagement;

namespace Code.Menu.Loading
{
    public class LoadingScene : MonoBehaviour
    {
        #region 环境

        private AudioSource sound;
        [SerializeField] private GameObject text;

        #endregion

        #region 初始化

        private void Awake()
        {
            sound = GetComponent<AudioSource>();
            sound.playOnAwake = true;
        }
        private void Start()
        {
            Invoke(nameof(Loading), 2f);
        }
        
        #endregion

        #region 处理

        private void FixedUpdate()
        {
            var eulerAngles = text.transform.eulerAngles;
            eulerAngles = Vector3.Lerp(eulerAngles, new Vector3(eulerAngles.x, eulerAngles.y + 4, eulerAngles.z + 4),
                1f);
            text.transform.eulerAngles = eulerAngles;
        }

        #endregion

        #region 行为

        private void Loading()
        {
            SceneManager.LoadScene("InGame");
        }

        #endregion
    }
}