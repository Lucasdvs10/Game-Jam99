using UnityEngine;

namespace GameManager {
    public class CheckIfItsFirstTimePlaying : MonoBehaviour {

        public bool Check() {
            if (!PlayerPrefs.HasKey("FIRSTTIMEOPENING")) {
                PlayerPrefs.SetInt("FIRSTTIMEOPENING", 0);

                return true;

            }
            return false;
            // return true;
        }

    }
}