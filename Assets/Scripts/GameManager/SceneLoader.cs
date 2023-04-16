using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameManager {
    public class SceneLoader : MonoBehaviour {
        public void LoadScene(string sceneName) {
            SceneManager.LoadScene(sceneName);
        }
    }
}