using UnityEngine;

namespace GameManager {
    [RequireComponent(typeof(SceneLoader))]
    public class LoadSceneOnTriggerEnter : MonoBehaviour {
        public string SceneName;
        private SceneLoader _sceneLoader;

        private void Awake() {
            _sceneLoader = GetComponent<SceneLoader>();
        }


        private void OnTriggerEnter2D(Collider2D col) {
            _sceneLoader.LoadScene(SceneName);
        }
    }
}