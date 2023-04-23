using UnityEngine;

namespace Player.StateMachine {
    public class StateManager : MonoBehaviour {
        private Transform[] _allStatesArray;
        public bool CanChangeState = true;
        public Transform CurrentState;

        private void Awake() {
            _allStatesArray = GetComponentsInChildren<Transform>(true);

        }

        public void ChangeState(Transform nextState) {
            if(!CanChangeState)
                return;
            
            foreach (var state in _allStatesArray) {
                if (state != nextState && state != transform) {
                    state.gameObject.SetActive(false);
                    CurrentState = state;
                }
            }
            nextState.gameObject.SetActive(true);
        } 
    }
}