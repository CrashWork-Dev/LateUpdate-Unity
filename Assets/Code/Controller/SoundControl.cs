using System;
using UnityEngine;

namespace Code.Controller
{
    public class SoundControl : Data.Data
    {
        [SerializeField] private AudioSource runSound;
        [SerializeField] private AudioSource jumpSound;
        [SerializeField] private AudioSource attackSound;
        [SerializeField] private Animator animator;
        [SerializeField] private Rigidbody playerRigidbody;
        private bool canJump;

        private void Update()
        {
            if (IsGround()) canJump = true;
            RunSound();
            JumpSound();
            AttackSound();
        }

        private bool IsGround()
        {
            return Physics.Raycast(playerRigidbody.position, Vector3.down, 0.08f);
        }
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
            else if(!jumpSound.isPlaying && canJump)
            {
                canJump = false;
                jumpSound.Play();
            }
        }
    }
}