using System;
using UnityEngine;

namespace Code.Weapon.Katana
{
    public class AttackBehaviour : StateMachineBehaviour
    {
        private GameObject obj;
        private BoxCollider collider;

        private void Awake()
        {
            obj = GameObject.Find("Katana");
            obj.SetActive(false);
        }

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            obj.SetActive(true);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            obj.SetActive(false);
        }
    }
}