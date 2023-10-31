using UnityEngine;

namespace Code.Controller
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float walkSpeed;
        private Controller controller;
        private Rigidbody player;
        private Animator animator;
        private static readonly int IsWalkingF = Animator.StringToHash("IsWalkingF");
        private static readonly int IsWalkingL = Animator.StringToHash("IsWalkingL");
        #region 初始化

        private void Start()
        {
            player = GetComponent<Rigidbody>();
            animator = GetComponent<Animator>();
            player.freezeRotation = true;
        }

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

        #region Process

        private void FixedUpdate()
        {
            Walk(GetControllerValueOfWasd());
        }

        #endregion
        
        private Vector2 GetControllerValueOfWasd()
        {
            return controller.InGame.Player.ReadValue<Vector2>();
        }
        private void Walk(Vector2 wasd)
        {
            //todo 前后移动左右移动单独动画
            animator.SetBool(IsWalkingF, wasd.y != Vector2.zero.y);
            animator.SetBool(IsWalkingL, wasd.x!= Vector2.zero.x);
            
            var transform1 = transform;
            var playerToward = (transform1.right * wasd.x + transform1.forward * wasd.y) * (Time.deltaTime * walkSpeed);
            player.velocity = playerToward;
        }
    }
}

