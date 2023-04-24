using UnityEngine;

namespace GameManager {
    public class CheckIfItsFirstTimePlaying : MonoBehaviour {

        public bool Check() {
            if (PlayerPrefs.GetInt("FIRSTTIMEOPENING", 1) == 1) {
                PlayerPrefs.SetInt("FIRSTTIMEOPENING", 1);

                return true;

            }

            return false;

            // return true;
        }

    }
}