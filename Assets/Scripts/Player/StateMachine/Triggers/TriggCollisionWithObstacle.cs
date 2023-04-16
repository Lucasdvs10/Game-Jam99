using UnityEngine;
using UnityEngine.Events;

namespace Player.StateMachine.Triggers {
    public class TriggCollisionWithObstacle : MonoBehaviour {
        public UnityEvent OnCollisionEvent;
        private void OnCollisionEnter2D(Collision2D col) {
            if (col.gameObject.CompareTag("Obstacle")) {
                OnCollisionEvent.Invoke();
            }
        }
    }
}