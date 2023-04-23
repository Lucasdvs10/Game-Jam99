using UnityEngine;

namespace GameManager {
    public class PauseManager : MonoBehaviour {
        private bool _isPaused;
        public GameObject PopUpGameObject;


        public void PauseGameOrQuitGame() { //Funcao que será chamada sempre que apertar esc
            if (!_isPaused) {
                PauseGame();
            }
            else {
                QuitGame();
            }
        }

        public void ResumeGameIfItsPaused() { //Funcao que será chamada sempre que apertar espaço
            if(_isPaused)
                ResumeGame();
        }
        
        public void PauseGame() {
            _isPaused = true;

            Time.timeScale = 0;
            OpenQuitGamePopUp();
            
        }

        public void ResumeGame() {
            _isPaused = false;

            Time.timeScale = 1;
            CloseQuitGamePopUp();
        }

        public void QuitGame() => Application.Quit();

        public void OpenQuitGamePopUp() {
            PopUpGameObject.SetActive(true);
        }
        
        public void CloseQuitGamePopUp() {
            PopUpGameObject.SetActive(false);
        }
    }
}