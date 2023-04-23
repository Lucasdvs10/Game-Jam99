using System;
using UnityEngine;

namespace Player.EnergySystem {
    [CreateAssetMenu(fileName = "new Singleton Integer", menuName = "Singletons/Integer", order = 0)]
    public class SOSingletonInt : ScriptableObject {
        public int Value;
        private Action _valueHasBeenChangedEvent;

        private void OnEnable() {
            _valueHasBeenChangedEvent = null;
        }

        public void ChangeValue(int newValue) {
            Value = newValue;
            _valueHasBeenChangedEvent?.Invoke();
        }

        public void SubscribeOnEvent(Action action) {
            _valueHasBeenChangedEvent += action;
        }
        
        public void UnsubscribeOnEvent(Action action) {
            _valueHasBeenChangedEvent -= action;
        }
        
    }
}