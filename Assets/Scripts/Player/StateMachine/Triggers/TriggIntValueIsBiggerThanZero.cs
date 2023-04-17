using Player.EnergySystem;
using UnityEngine;
using UnityEngine.Events;

namespace Player.StateMachine.Triggers {
    public class TriggIntValueIsBiggerThanZero : MonoBehaviour {
        public UnityEvent ValueIsBiggerThanZeroEvent;
        public SOSingletonInt IntValueSingleton;

        private bool _triggerIsOn = true;
        private void OnEnable() {
            IntValueSingleton.SubscribeOnEvent(CheckIfValueIsBiggerThanZero);
        }

        private void OnDisable() {
            IntValueSingleton.UnsubscribeOnEvent(CheckIfValueIsBiggerThanZero);
        }

        public void CheckIfValueIsBiggerThanZero() {
            if (IntValueSingleton.Value > 0 && _triggerIsOn) {
                ValueIsBiggerThanZeroEvent.Invoke();
            }
        }

        public void SetTriggerIsOnFlag(bool newValue) => _triggerIsOn = newValue;
    }
}