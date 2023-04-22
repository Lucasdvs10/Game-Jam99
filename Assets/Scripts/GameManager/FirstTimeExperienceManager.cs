using UnityEngine;

namespace GameManager {
    [RequireComponent(typeof(CheckIfItsFirstTimePlaying))]
    public class FirstTimeExperienceManager : MonoBehaviour {
        [SerializeField] private SpriteRenderer _spriteRendererBackground;
        [SerializeField] private Sprite _firstTimePlayingSprite;
        [SerializeField] private Sprite _defaultSprite;
        private CheckIfItsFirstTimePlaying _checkIfItsFirstTime;

        private bool[] FirstTimeChecksArray = {false, false, false, false, false, false, false};
        
        private void Awake() {
            _checkIfItsFirstTime = GetComponent<CheckIfItsFirstTimePlaying>();
        }

        public void UpdateFirstTimeChecksArray(int index) {
            FirstTimeChecksArray[index] = true;
            VerifyIfFirstTimeExperienceIsOver();
        }

        public void UpdateFirstTimeChecksArray(Vector2 direction) {
            if(direction == Vector2.up) UpdateFirstTimeChecksArray(3);
            if(direction == Vector2.down) UpdateFirstTimeChecksArray(4);
            if(direction == Vector2.right) UpdateFirstTimeChecksArray(5);
            if(direction == Vector2.left) UpdateFirstTimeChecksArray(6);
        }

        public void VerifyIfFirstTimeExperienceIsOver() {
            _spriteRendererBackground.sprite = _firstTimePlayingSprite;
            
            foreach (var check in FirstTimeChecksArray) {
                if (!check) {
                    return;
                }
            }
            
            _spriteRendererBackground.sprite = _defaultSprite;
        }

        private void Start() {
            if (!_checkIfItsFirstTime.Check()) {
                _spriteRendererBackground.sprite = _defaultSprite;
            }
            
            else
                VerifyIfFirstTimeExperienceIsOver();
        }
    }
}