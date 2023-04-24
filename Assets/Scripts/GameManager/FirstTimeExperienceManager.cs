using System.IO;
using UnityEngine;
using UnityEngine.Events;

namespace GameManager {
    [RequireComponent(typeof(CheckIfItsFirstTimePlaying))]
    public class FirstTimeExperienceManager : MonoBehaviour {
        [SerializeField] private Animator _animator;
        public UnityEvent FirstTimeExpIsOver;
        public UnityEvent FirstTimeArrowsIsOver;
        public UnityEvent FirstTimeShiftIsOver;
        public UnityEvent FirstTimeSpaceIsOver;
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
            
            if(FirstTimeChecksArray[2] && FirstTimeChecksArray[3] && FirstTimeChecksArray[4] && FirstTimeChecksArray[5])
                FirstTimeArrowsIsOver.Invoke();
        }

        public void InvokeFirstTimeShiftIsOver() => FirstTimeShiftIsOver.Invoke();
        public void InvokeFirstTimeSpaceIsOver() => FirstTimeSpaceIsOver.Invoke();

        public void VerifyIfFirstTimeExperienceIsOver() {
            foreach (var check in FirstTimeChecksArray) {
                if (!check) {
                    return;
                }
            }
            
            FirstTimeExpIsOver.Invoke();
            _animator.Play("Aquario_Aberto");
        }

        private void Start() {
            if (!_checkIfItsFirstTime.Check()) {
                for (var i = 0; i< FirstTimeChecksArray.Length; i++) {
                    FirstTimeChecksArray[i] = true;
                }
                _animator.Play("Aquario_Aberto");
            }
            
            else
                VerifyIfFirstTimeExperienceIsOver();
        }

        [ContextMenu("Limpar as player prefs")]
        public void CleanPlayerPrefs() {
            string path = Application.dataPath + $"/JaJogou.json";
            File.Delete(path);
        }
    }
}