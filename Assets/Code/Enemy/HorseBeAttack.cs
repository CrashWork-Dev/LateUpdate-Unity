using Code.Enemy.Interface;
using UnityEngine;

namespace Code.Enemy
{
    public class HorseBeAttack : MonoBehaviour,IHorseAction
    {
        [SerializeField] private GameObject obj;
        [SerializeField] private new BoxCollider collider;

        public void Die()
        {
            Destroy(obj);
        }

        private void OnTriggerEnter(Collider others)
        {
            if (others != collider) return;
            obj.transform.up += new Vector3(0,4,0);
            Invoke(nameof(Die),1);

        }
    }
}