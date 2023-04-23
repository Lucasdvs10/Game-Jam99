using UnityEditor.Animations;
using UnityEngine;
using UnityEngine.Events;

namespace GameManager {
    [RequireComponent(typeof(CheckIfItsFirstTimePlaying))]
    public class FirstTimeExperienceManager : MonoBehaviour {
        [SerializeField] private Animator _animator;
        [SerializeField] private AnimatorController _firstTimePlayingSprite;
        [SerializeField] private AnimatorController _defaultSprite;
        public UnityEvent FirstTimeExpIsOver;
        private CheckIfItsFirstTimePlaying _checkIfItsFirstTime;

        private bool[] FirstTimeChecksArray = {false, false, false, false, false, false };
        
        private void Awake() {
            _checkIfItsFirstTime = GetComponent<CheckIfItsFirstTimePlaying>();
        }

        public void UpdateFirstTimeChecksArray(int index) {
            FirstTimeChecksArray[index] = true;
            VerifyIfFirstTimeExperienceIsOver();
        }

        public void UpdateFirstTimeChecksArray(Vector2 direction) {
            if(direction == Vector2.up) UpdateFirstTimeChecksArray(2);
            if(direction == Vector2.down) UpdateFirstTimeChecksArray(3);
            if(direction == Vector2.right) UpdateFirstTimeChecksArray(4);
            if(direction == Vector2.left) UpdateFirstTimeChecksArray(5);
        }

        public void VerifyIfFirstTimeExperienceIsOver() {
            foreach (var check in FirstTimeChecksArray) {
                if (!check) {
                    _animator.runtimeAnimatorController = _firstTimePlayingSprite;
                    return;
                }
            }
            
            FirstTimeExpIsOver.Invoke();
            _animator.runtimeAnimatorController = _defaultSprite;
        }

        private void Start() {
            if (!_checkIfItsFirstTime.Check()) {
                print("teste");
                _animator.runtimeAnimatorController = _defaultSprite;

                for (var i = 0; i< FirstTimeChecksArray.Length; i++) {
                    FirstTimeChecksArray[i] = true;
                }
            }
            
            else
                VerifyIfFirstTimeExperienceIsOver();
        }

        [ContextMenu("Limpar as player prefs")]
        public void CleanPlayerPrefs() {
            PlayerPrefs.DeleteAll();
        }
    }
}