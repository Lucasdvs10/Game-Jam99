using UnityEngine;

namespace PlayerMovement {
    public class PlayerMovement : MonoBehaviour {
        [SerializeField] float _playerMovementSpeed;
        [SerializeField] private bool _mantainInertia;
        
        private Rigidbody2D _playerRgb;
        private Transform _playerTransform;

        private void Awake() {
            _playerRgb = GetComponentInParent<Rigidbody2D>();
            _playerTransform = _playerRgb.transform;
        }

        public void MovePlayer(Vector2 direction) {
            _playerRgb.velocity = _playerTransform.localToWorldMatrix * (direction * _playerMovementSpeed);
        }

        public void StopPlayerMovement() {
            if(_mantainInertia) return;
            
            _playerRgb.velocity = Vector2.zero;
        }
        
    }
}