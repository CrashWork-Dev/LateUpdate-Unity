using UnityEngine;
using UnityEngine.InputSystem;

namespace Code.Controller
{
    public class Player : MonoBehaviour
    {
        [SerializeField] private float walkSpeed;
        [SerializeField] private Vector3 jumpForce;
        private Controller controller;
        private Rigidbody player;
        private Animator animator;

        private static readonly int IsWalkingF = Animator.StringToHash("IsWalkingF");
        private static readonly int IsWalkingL = Animator.StringToHash("IsWalkingL");
        private static readonly int IsWalkingB = Animator.StringToHash("IsWalkingB");
        private static readonly int IsWalkingR = Animator.StringToHash("IsWalkingR");
        private static readonly int IsJumping = Animator.StringToHash("IsJumping");
        private static readonly int Ground = Animator.StringToHash("IsGround");
        private static readonly int IsRunning = Animator.StringToHash("IsRunning");

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
            controller.InGame.Jump.started += Jump;
            controller.InGame.Run.performed += Run;
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
            Check(IsGround());
            //Run();
        }

        private Vector2 GetControllerValueOfWasd()
        {
            return controller.InGame.Player.ReadValue<Vector2>();
        }

        #endregion


        private bool IsGround()
        {
            return Physics.Raycast(player.position, Vector3.down, 0.5f);
        }

        private void Check(bool isGround)
        {
            if (isGround) animator.SetTrigger(Ground);
        }

        private void Walk(Vector2 wasd)
        {
            animator.SetBool(IsWalkingF, wasd.y > Vector2.zero.y);
            animator.SetBool(IsWalkingB, wasd.y < Vector2.zero.y);
            animator.SetBool(IsWalkingL, wasd.x < Vector2.zero.x);
            animator.SetBool(IsWalkingR, wasd.x > Vector2.zero.x);

            var transform1 = transform;
            var playerToward = (transform1.right * wasd.x + transform1.forward * wasd.y) * (Time.deltaTime * walkSpeed);
            player.velocity = playerToward;
        }

        //todo 跳跃手感优化
        private void Jump(InputAction.CallbackContext obj)
        {
            if (!IsGround()) return;
            animator.SetTrigger(IsJumping);
            player.AddForce(jumpForce, ForceMode.Impulse);
        }

        //todo 玩家疾跑动画实现
        private void Run(InputAction.CallbackContext obj)
        {
            //animator.SetBool(IsRunning, controller.InGame.Run.IsPressed());
            walkSpeed = 100;
        }
        /*
        private void Run()
        {
            animator.SetBool(IsRunning, controller.InGame.Run.IsPressed());
            if (!controller.InGame.Run.IsPressed()) walkSpeed = 50;
        }
        */
    }
}