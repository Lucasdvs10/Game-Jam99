using UnityEngine;
using UnityEngine.Events;

namespace Player.StateMachine.Actions {
    public class OnStateEnter : MonoBehaviour {
        public UnityEvent OnStateEnterEvent;

        private void OnEnable() {
            OnStateEnterEvent.Invoke();
        }
    }
}