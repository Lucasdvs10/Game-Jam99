using System;
using UnityEngine;
using UnityEngine.Events;

namespace Player.StateMachine.Actions {
    public class StateTransitionBlocker : MonoBehaviour {
        [SerializeField] private int _numberOfHitsToUnblockTransition;
        public UnityEvent UnblockStateTransitionEvent;
        private int _hitsCounter;

        public void Initialize() {
            _hitsCounter = 0;
        }

        private void Update() {
            if(_hitsCounter >= _numberOfHitsToUnblockTransition)
                UnblockStateTransition();
        }

        public void BlockStateTransition() {
            Initialize();
            var player = GameObject.FindWithTag("Player");
            player.GetComponentInChildren<StateManager>().CanChangeState = false;
        }

        
        public void UnblockStateTransition() {
            Initialize();
            var player = GameObject.FindWithTag("Player");
            player.GetComponentInChildren<StateManager>().CanChangeState = true;
            UnblockStateTransitionEvent.Invoke();
        }
        
        public void AddOneToHitsCounter() {
            _hitsCounter++;
        }
    }
}