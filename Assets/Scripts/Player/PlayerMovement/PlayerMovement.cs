﻿using Enemies.Bird;
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
        private Vector2 _directionBuffer;

        private bool _isMovingWithBird;
        private Rigidbody2D _birdRgb;

        private void Awake() {
            _playerRgb = GetComponentInParent<Rigidbody2D>();
            _playerTransform = _playerRgb.transform;
            _birdRgb = FindObjectOfType<BirdMovement>()?.GetComponent<Rigidbody2D>();
        }

        private void Update() {
            if (_isMovingWithBird && _birdRgb)
                _playerRgb.velocity = _birdRgb.velocity;

        }

        public void MovePlayer(Vector2 direction) {
            if(!_playerCanMove)
                return;

            _playerRgb.velocity = (_playerTransform.localToWorldMatrix * direction).normalized * _playerMovementSpeed;
            RotateSprite(direction);
        }

        public void MovePlayerToDirectionBuffer() {
            if (_playerTransform == null || _playerRgb == null) {
                // var message = _playerRgb == null ? "O rgb do player é nulo!" : "O transform do player é nulo!";
                // print(message);
                return;
            }
            _playerRgb.velocity = (_playerTransform.localToWorldMatrix * _directionBuffer).normalized * _playerMovementSpeed;
            RotateSprite(_directionBuffer);
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
        public void SetDirectionBuffer(Vector2 direction) => _directionBuffer = direction;

        public void SetFollowBirdFlag(bool newValue) => _isMovingWithBird = newValue;
        public float PlayerMovementSpeed => (_playerMovementSpeed * _directionBuffer).x;
    }
}