using Player.EnergySystem;
using UnityEngine;
using UnityEngine.Events;

namespace Player.StateMachine.Triggers {
    public class TriggIntValueIsZeroOrLess : MonoBehaviour {
        public UnityEvent ValueIsZeroOrLessEvent;
        public SOSingletonInt IntValueSingleton;

        private void OnEnable() {
            IntValueSingleton.SubscribeOnEvent(CheckIfValueIsZeroOrLess);
        }

        private void OnDisable() {
            IntValueSingleton.UnsubscribeOnEvent(CheckIfValueIsZeroOrLess);
        }

        public void CheckIfValueIsZeroOrLess() {
            if (IntValueSingleton.Value <= 0) {
                ValueIsZeroOrLessEvent.Invoke();
            }
        }
        
    }
}