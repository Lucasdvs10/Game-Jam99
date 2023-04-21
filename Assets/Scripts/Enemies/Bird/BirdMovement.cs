using UnityEngine;

namespace Enemies.Bird {
    public class BirdMovement : MonoBehaviour {
        private Rigidbody2D _rb;
        private float _speed;
        private PlayerMovement.PlayerMovement _playerMovement;
    
        private void Awake() {
            _rb = GetComponent<Rigidbody2D>();
            _playerMovement = FindObjectOfType<PlayerMovement.PlayerMovement>();
        }

        public void SetMovementSpeed(float newValue) => _speed = newValue;
        
        public void SetDirectionToSuperiorLeftDiagonal(float speedValue) {
            Awake();
            SetMovementSpeed(speedValue);
            _rb.velocity = transform.localToWorldMatrix *new Vector2(0,1) * _speed;
        }
        
        public void SetDirectionToSuperiorRigthDiagonal(float speedValue) {
            Awake();
            SetMovementSpeed(speedValue);
            _rb.velocity = transform.localToWorldMatrix * (new Vector2(1, 0) * _speed);
        }

    }
}