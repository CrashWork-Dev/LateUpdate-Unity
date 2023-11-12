using UnityEngine;
using UnityEngine.UI;

namespace Code.Controller
{
    public class UI : Data.Data
    {
        #region 环境

        private Text hpAndScore;
        private int tempScore;
        [SerializeField] private Animator animator;

        #endregion

        #region 初始化

        private void Awake()
        {
            hpAndScore = GetComponentInChildren<Text>();
        }

        private void HpFalling()
        {
            animator.SetInteger(Hp, animator.GetInteger(Hp) - 1);
        }
        
        #endregion

        #region 处理

        private void FixedUpdate()
        {
            HpFalling();
            if (tempScore != animator.GetInteger(Score))
            {
                tempScore = animator.GetInteger(Score);
                animator.SetInteger(Hp, 200);
            }

            hpAndScore.text = "热情值: " + animator.GetInteger(Hp) + "  得分: " + animator.GetInteger(Score);
        }

        #endregion
    }
}