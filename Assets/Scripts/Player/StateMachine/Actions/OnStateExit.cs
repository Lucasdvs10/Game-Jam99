using UnityEngine;
using UnityEngine.Events;

namespace Player.StateMachine.Actions {
    public class OnStateExit : MonoBehaviour {
        public UnityEvent OnStateExitEvent;
        private void OnDisable() {
            OnStateExitEvent?.Invoke();
        }
    }
}