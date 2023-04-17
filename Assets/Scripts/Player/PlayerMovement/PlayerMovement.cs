using UnityEngine;

namespace PlayerMovement {
    public class PlayerMovement : MonoBehaviour {
        [SerializeField] float _playerMovementSpeed;
        [SerializeField] private Transform _spriteTransform;

        private bool _mantainInertia;
        private bool _playerCanMove = true;
        private Rigidbody2D _playerRgb;
        private Transform _playerTransform;
        private bool _playerIsTriyngToMove;

        private void Awake() {
            _playerRgb = GetComponentInParent<Rigidbody2D>();
            _playerTransform = _playerRgb.transform;
        }

        public void MovePlayer(Vector2 direction) {
            if(!_playerCanMove)
                return;
            
            _playerRgb.velocity = _playerTransform.localToWorldMatrix * (direction * _playerMovementSpeed);
            RotateSprite(direction);
        }

        public void RotateSprite(Vector2 direction) {
            if (direction == Vector2.up)
                _spriteTransform.localRotation = Quaternion.Euler(0,-180,45);
            
            else if (direction == Vector2.down)
                _spriteTransform.localRotation = Quaternion.Euler(0, 0, -102f);
            
            else if (direction == Vector2.right)
                _spriteTransform.localRotation = Quaternion.Euler(0, 0, -45f);
            
            else if (direction == Vector2.left) 
                _spriteTransform.localRotation = Quaternion.Euler(0,180,-30);

            else {
                var stringDirectionX = direction.x.ToString("0.00");
                var stringDirectionY = direction.y.ToString("0.00");

                if (stringDirectionX == "0,71" && stringDirectionY == "0,71")
                    _spriteTransform.localRotation = Quaternion.Euler(0,0,14f);
                
                else if (stringDirectionX == "0,71" && stringDirectionY == "-0,71")
                    _spriteTransform.localRotation = Quaternion.Euler(0,0,-78f);
                
                if (stringDirectionX == "-0,71" && stringDirectionY == "0,71")
                    _spriteTransform.localRotation = Quaternion.Euler(0,180,-5f);
                
                else if (stringDirectionX == "-0,71" && stringDirectionY == "-0,71")
                    _spriteTransform.localRotation = Quaternion.Euler(0,0,180);
                
            }
        }
        
        public void ApplyInertiaIfFlagIsOn() {
            if(_mantainInertia) return;
            
            _playerRgb.velocity = Vector2.zero;
        }

        public void StopPlayerMovement() {
            if(!_playerIsTriyngToMove)
                _playerRgb.velocity = Vector2.zero;
        }

        public void SetPlayerIsTryingToMoveFlag(bool newValue) => _playerIsTriyngToMove = newValue;
        public void SetPlayerCanMoveFlag(bool newValue) => _playerCanMove = newValue;
        public void SetMantainInertiaFlag(bool newValue) => _mantainInertia = newValue;
    }
}