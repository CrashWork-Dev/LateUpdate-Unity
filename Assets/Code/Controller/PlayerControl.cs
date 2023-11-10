using System;
using Code.Controller.Interface;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Code.Controller
{
    public class PlayerControl : Data.Data, IPlayerAction, ICameraAction
    {
        #region 环境
        [SerializeField] private new Camera camera;
        private Controller controller;
        private Rigidbody playerRigidbody;
        private Animator animator;
        private CapsuleCollider playerCollider;
        private bool onWall;
        [SerializeField] private float fallSpeed;
        #endregion

        #region 初始化

        private void Start()
        {
            playerRigidbody = GetComponent<Rigidbody>();
            animator = GetComponent<Animator>();
            playerRigidbody.freezeRotation = true;
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
            ((ICameraAction)this).CameraFov(animator.GetBool(IsRunning));
            Check(IsGround());
            Falling();
            fallSpeed = 6;
            onWall = false;
        }

        private Vector2 GetControllerValueOfWasd()
        {
            return controller.InGame.Player.ReadValue<Vector2>();
        }

        private void Falling()
        {
            if (!IsGround())
            {
                playerRigidbody.velocity += new Vector3(0, -fallSpeed, 0);
            }
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
            walkSpeed = animator.GetBool(IsRunning) ? 400 : 200;
            
        }
        
        void IPlayerAction.Jump(InputAction.CallbackContext obj)
        {
            if (!IsGround() && !onWall) return;
            onWall = false;
            if (GetControllerValueOfWasd() == Vector2.zero) animator.SetTrigger(IsJumping); 
            playerRigidbody.AddForce(jumpForce, ForceMode.Impulse);

        }

        // void IPlayerAction.Dash()
        // {
        //     if (!IsGround() && Keyboard.current.spaceKey.wasPressedThisFrame)
        //     {
        //         playerRigidbody.velocity =
        //             Vector3.Lerp(playerRigidbody.velocity, GetPlayerToward(GetControllerValueOfWasd()) * 20, 1000);
        //     }
        // }
        //todo 跳跃碰撞体跟随
        void IPlayerAction.ResetCollider()
        {
            
        }

        void IPlayerAction.Attack(InputAction.CallbackContext obj)
        {
            animator.SetTrigger(IsAttacking);
        }

        private void OnTriggerStay(Collider other)
        {
            if(other.CompareTag("wall")) fallSpeed = 0;
            onWall = true;
        }

        #endregion
    }
}