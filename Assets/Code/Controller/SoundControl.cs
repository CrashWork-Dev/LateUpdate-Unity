using UnityEngine;

namespace Code.Controller
{
    public class SoundControl : Data.Data
    {
        #region 环境

        [SerializeField] private AudioSource runSound;
        [SerializeField] private AudioSource jumpSound;
        [SerializeField] private AudioSource attackSound;
        [SerializeField] private Animator animator;
        [SerializeField] private Rigidbody playerRigidbody;
        private bool canJump;

        #endregion

        #region 处理
        
        private bool IsGround()
        {
            return Physics.Raycast(playerRigidbody.position, Vector3.down, 0.08f);
        }
        private void Update()
        {
            if (IsGround()) canJump = true;
            RunSound();
            JumpSound();
            AttackSound();
        }

        #endregion

        #region 动作

        private void RunSound()
        {
            if (animator.GetBool(IsRunning) && IsGround() && !runSound.isPlaying)
            {
                runSound.Play();
            }

            if (!IsGround())
            {
                runSound.Stop();
            }
        }

        private void AttackSound()
        {
            if (attackSound.isPlaying || !animator.GetBool(IsAttacking)) return;
            attackSound.Play();
        }

        private void JumpSound()
        {
            if (IsGround()) jumpSound.Stop();
            else if (!jumpSound.isPlaying && canJump)
            {
                canJump = false;
                jumpSound.Play();
            }
        }

        #endregion
    }
}