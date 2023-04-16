using UnityEngine;

namespace PlayerMovement {
    public class PlayerMovement : MonoBehaviour {
        [SerializeField] float _playerMovementSpeed;
        [SerializeField] private bool _mantainInertia;
        [SerializeField] private Transform _spriteTransform;
        
        private Rigidbody2D _playerRgb;
        private Transform _playerTransform;

        private void Awake() {
            _playerRgb = GetComponentInParent<Rigidbody2D>();
            _playerTransform = _playerRgb.transform;
        }

        public void MovePlayer(Vector2 direction) {
            _playerRgb.velocity = _playerTransform.localToWorldMatrix * (direction * _playerMovementSpeed);
            RotateSprite(direction);
        }

        public void RotateSprite(Vector2 direction) {
            if (direction == Vector2.up)
                _spriteTransform.localRotation = Quaternion.Euler(0, 0, 90f);
            
            if (direction == Vector2.down)
                _spriteTransform.localRotation = Quaternion.Euler(0, 0, -90f);
            
            if (direction == Vector2.right)
                _spriteTransform.localRotation = Quaternion.Euler(0, 0, 0f);
            
            if (direction == Vector2.left)
                _spriteTransform.localRotation = Quaternion.Euler(0, 0, 0f);
            
            // if (direction == new Vector2(0.71f, 0.71f)) Não sei pq não está funcionando
            //     _spriteTransform.localRotation = Quaternion.Euler(0,0,45f);
            //
            // if (direction == new Vector2(0.71f,-0.71f))
            //     _spriteTransform.localRotation = Quaternion.Euler(0,0,-45f);
        }
        
        public void StopPlayerMovement() {
            if(_mantainInertia) return;
            
            _playerRgb.velocity = Vector2.zero;
        }
        
    }
}