using UnityEngine;

namespace GameManager {
    public class CheckIfItsFirstTimePlaying : MonoBehaviour {

        public bool Check() {
            if (PlayerPrefs.GetInt("FIRSTTIMEOPENING", 1) == 1) {
                Debug.Log("First Time Opening");

                //Set first time opening to false
                PlayerPrefs.SetInt("FIRSTTIMEOPENING", 0);

                return true;

            }
            else {
                Debug.Log("NOT First Time Opening");

                return false;
            }
        }

        public void Kappa() {

        }
    }
}