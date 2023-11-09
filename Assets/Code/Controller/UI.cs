using UnityEngine;
using UnityEngine.UI;

namespace Code.Controller
{
    public class UI : Data.Data
    {
        private Text hpAndScore;
        private int tempScore;
        [SerializeField] private Animator animator;
        

        private void Awake()
        {
            hpAndScore = GetComponentInChildren<Text>();
        }

        private void HpFalling()
        {
            animator.SetInteger(Hp,animator.GetInteger(Hp)-1);
        }
        private void FixedUpdate()
        {
            HpFalling();
            if (tempScore != animator.GetInteger(Score))
            {
                tempScore = animator.GetInteger(Score);
                animator.SetInteger(Hp,200);
            }
            hpAndScore.text = "热情值: "+animator.GetInteger(Hp) +"  得分: "+animator.GetInteger(Score);
        }
    }
}