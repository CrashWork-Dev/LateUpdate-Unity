﻿using Code.Enemy.Interface;
using UnityEngine;
namespace Code.Enemy
{
    public class Horse : Data.Data,IHorseAction
    {
        [SerializeField] private GameObject obj;
        [SerializeField] private new BoxCollider collider;
        private Rigidbody horseRigidbody;
        [SerializeField] private Animator animator;

        private void Awake()
        {
            horseRigidbody = obj.GetComponent<Rigidbody>();
            horseRigidbody.freezeRotation = true;
        }

        public void Die()
        {
            Destroy(obj);
        }
        
        private void OnTriggerEnter(Collider others)
        {
            if (others != collider) return;
            obj.transform.up += new Vector3(0,4,0);
            animator.SetInteger(Score,animator.GetInteger(Score)+1);
            Invoke(nameof(Die),0.5f);
        }
    }
}