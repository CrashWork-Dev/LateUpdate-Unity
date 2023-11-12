using System;
using UnityEngine;

namespace Code.Weapon.Katana
{
    public class AttackBehaviour : StateMachineBehaviour
    {
        #region 环境

        private GameObject obj;
                private BoxCollider collider;

        #endregion

        #region 初始化

        private void Awake()
        {
            obj = GameObject.Find("Katana");
            obj.SetActive(false);
        }

        #endregion

        #region 处理

        public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            obj.SetActive(true);
        }

        public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            obj.SetActive(false);
        }

        #endregion
    }
}