using Code.Controller.Interface;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Code.Controller
{
    public class Player : MonoBehaviour, IPlayerAction, ICameraAction
    {
        #region 环境
        [SerializeField] private float walkSpeed;
        [SerializeField] private Vector3 jumpForce;
        [SerializeField] private new Camera camera;
        private Controller controller;
        private Rigidbody playerRigidbody;
        private Animator animator;
        private CapsuleCollider playerCollider;
        private float orgColHight;
        private Vector3 orgVectColCenter;
        private static readonly int IsWalkingF = Animator.StringToHash("IsWalkingF");
        private static readonly int IsWalkingL = Animator.StringToHash("IsWalkingL");
        private static readonly int IsWalkingB = Animator.StringToHash("IsWalkingB");
        private static readonly int IsWalkingR = Animator.StringToHash("IsWalkingR");
        private static readonly int IsJumping = Animator.StringToHash("IsJumping");
        private static readonly int Ground = Animator.StringToHash("IsGround");
        private static readonly int IsRunning = Animator.StringToHash("IsRunning");
        private static readonly int IsAttacking = Animator.StringToHash("IsAttacking");

        #endregion

        #region 初始化

        private void Start()
        {
            playerRigidbody = GetComponent<Rigidbody>();
            animator = GetComponent<Animator>();
            playerRigidbody.freezeRotation = true;
            //orgColHight = playerCollider.height;
            //orgVectColCenter = playerCollider.center;
        }

        private void Awake()
        {
            controller = new Controller();
            controller.InGame.Jump.started += ((IPlayerAction)this).Jump;
            controller.InGame.Attack.started += ((IPlayerAction)this).Attack;
        }


        private void OnEnable()
        {
            controller.Enable();
        }

        private void OnDisable()
        {
            controller.Disable();
        }

        void ICameraAction.CameraFov(bool isRun)
        {
            camera.fieldOfView = isRun ? 98 : 85;
        }
        #endregion

        #region 处理

        private void FixedUpdate()
        {
            ((IPlayerAction)this).Walk(GetControllerValueOfWasd());
            ((IPlayerAction)this).Run();
            ((IPlayerAction)this).Dash();
            ((ICameraAction)this).CameraFov(animator.GetBool(IsRunning));
            Check(IsGround());
            Falling();
        }

        private Vector2 GetControllerValueOfWasd()
        {
            return controller.InGame.Player.ReadValue<Vector2>();
        }

        private void Falling()
        {
            if (!IsGround()) playerRigidbody.velocity += Physics.gravity;
        }

        private bool IsGround()
        {
            return Physics.Raycast(playerRigidbody.position, Vector3.down, 0.08f);
        }

        private void Check(bool isGround)
        {
            if (isGround) animator.SetTrigger(Ground);
        }

        private Vector3 GetPlayerToward(Vector2 wasd)
        {
            var transform1 = transform;
            return (transform1.right * wasd.x + transform1.forward * wasd.y) * (Time.deltaTime * walkSpeed);
        }

        #endregion

        #region 动作

        void IPlayerAction.Walk(Vector2 wasd)
        {
            animator.SetBool(IsWalkingF, wasd.y > Vector2.zero.y);
            animator.SetBool(IsWalkingB, wasd.y < Vector2.zero.y);
            animator.SetBool(IsWalkingL, wasd.x < Vector2.zero.x);
            animator.SetBool(IsWalkingR, wasd.x > Vector2.zero.x);
            playerRigidbody.velocity = GetPlayerToward(wasd);
        }

        void IPlayerAction.Run()
        {
            animator.SetBool(IsRunning,
                Keyboard.current.shiftKey.isPressed && GetControllerValueOfWasd() != Vector2.zero);
            walkSpeed = Keyboard.current.shiftKey.isPressed ? 400 : 200;
        }
        
        void IPlayerAction.Jump(InputAction.CallbackContext obj)
        {
            if (!IsGround()) return;
            if (GetControllerValueOfWasd() == Vector2.zero) animator.SetTrigger(IsJumping);
            playerRigidbody.AddForce(jumpForce, ForceMode.VelocityChange);
        }

        void IPlayerAction.Dash()
        {
            if (!IsGround() && Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                playerRigidbody.velocity =
                    Vector3.Lerp(playerRigidbody.velocity, GetPlayerToward(GetControllerValueOfWasd()) * 20, 1000);
            }
        }
        //todo 跳跃碰撞体跟随
        void IPlayerAction.ResetCollider()
        {
            
        }

        void IPlayerAction.Attack(InputAction.CallbackContext obj)
        {
            animator.SetTrigger(IsAttacking);
            
        }
        #endregion
    }
}