using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Code.Menu.Loading
{
    public class LoadingScene : MonoBehaviour
    {
        private AudioSource sound;
        [SerializeField] private GameObject text;
        private void Awake()
        {
            sound = GetComponent<AudioSource>();
            sound.playOnAwake = true;
        }

        private void FixedUpdate()
        {
            var eulerAngles = text.transform.eulerAngles;
            eulerAngles = Vector3.Lerp(eulerAngles,new Vector3(eulerAngles.x,eulerAngles.y+4,eulerAngles.z+4) , 1f);
            text.transform.eulerAngles = eulerAngles;
        }

        private void Start()
        {
            
            Invoke(nameof(Loading),2f);
            
        }

        private void Loading()
        {
            SceneManager.LoadSceneAsync("InGame", LoadSceneMode.Single);
        }
        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
