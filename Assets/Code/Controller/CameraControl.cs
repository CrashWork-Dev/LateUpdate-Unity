using UnityEngine;

namespace Code.Controller
{
    public class CameraControl : MonoBehaviour
    {
        [SerializeField] private GameObject camera;
        [SerializeField] private GameObject player;
        [SerializeField] private float mouseSensitivity;
        private Controller controller;
        private float cameraH, cameraV;

        #region 初始化

        private void Awake()
        {
            controller = new Controller();
        }

        private void OnEnable()
        {
            controller.Enable();
        }

        private void OnDisable()
        {
            controller.Disable();
        }

        #endregion

        private void LateUpdate()
        {
            CameraMove();
        }

        private Vector3 GetMousePosition()
        {
            return new Vector3(Input.mousePositionDelta.x, Input.mousePositionDelta.y);
        }

        private void CameraMove()
        {
            cameraH += GetMousePosition().x * Time.deltaTime * mouseSensitivity;
            cameraV -= GetMousePosition().y * Time.deltaTime * mouseSensitivity;
            cameraV = Mathf.Clamp(cameraV, -70, 40);
            var cameraR = new Vector3(cameraV, cameraH, 0);
            var playerR = new Vector3(0, cameraH, 0);
            transform.eulerAngles = Vector3.Lerp(camera.transform.eulerAngles, cameraR, 1f);
            player.transform.eulerAngles = Vector3.Lerp(player.transform.eulerAngles, playerR, 1f);
        }
    }
}