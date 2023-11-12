using UnityEngine;

namespace Code.Data
{
    public class Data : MonoBehaviour
    {
        [SerializeField] protected float walkSpeed;
        [SerializeField] protected Vector3 jumpForce;
        protected float orgColHight;
        protected Vector3 orgVectorColCenter;
        protected static readonly int IsWalkingF = Animator.StringToHash("IsWalkingF");
        protected static readonly int IsWalkingL = Animator.StringToHash("IsWalkingL");
        protected static readonly int IsWalkingB = Animator.StringToHash("IsWalkingB");
        protected static readonly int IsWalkingR = Animator.StringToHash("IsWalkingR");
        protected static readonly int IsJumping = Animator.StringToHash("IsJumping");
        protected static readonly int Ground = Animator.StringToHash("IsGround");
        protected static readonly int IsRunning = Animator.StringToHash("IsRunning");
        protected static readonly int IsAttacking = Animator.StringToHash("IsAttacking");
        protected static readonly int Score = Animator.StringToHash("Score");
        protected static readonly int Hp = Animator.StringToHash("Hp");
    }
}