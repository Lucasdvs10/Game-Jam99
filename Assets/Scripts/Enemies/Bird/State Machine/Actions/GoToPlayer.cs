using System;
using UnityEngine;
using UnityEngine.Events;

namespace Enemies.Bird.State_Machine.Actions {
    public class GoToPlayer : MonoBehaviour {
        [SerializeField] private float _movementSpeed;
        private Transform _targetTransform;
        private Rigidbody2D _rgb;
        public UnityEvent ArrivedAtTargetEvent;
        private bool _isChasingPlayer;
        public void Initialize() {
            _rgb = GetComponentInParent<Rigidbody2D>();
            _targetTransform = GameObject.FindWithTag("Player").transform;
        }

        private void Update() {
            if(_isChasingPlayer)
                GoToTarget(_movementSpeed);
        }

        public void ActivateChasePlayer(bool newValue) {
            _isChasingPlayer = newValue;
        }
        
        public void GoToTarget(float speed) {
            if(_rgb == null || _targetTransform == null)
                Initialize();
            var direction = (_targetTransform.position - transform.position).normalized;

            _rgb.velocity = direction * speed;
        }

        private void OnTriggerEnter2D(Collider2D col) {
            if(col.CompareTag("Player"))
                ArrivedAtTargetEvent.Invoke();
        }
    }
}