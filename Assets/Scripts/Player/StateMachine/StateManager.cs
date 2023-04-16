using UnityEngine;

namespace Player.StateMachine {
    public class StateManager : MonoBehaviour {
        private Transform[] _allStatesArray;

        private void Awake() {
            _allStatesArray = GetComponentsInChildren<Transform>(true);

        }

        public void ChangeState(Transform nextState) {
            foreach (var state in _allStatesArray) {
                if(state != nextState && state != transform) 
                    state.gameObject.SetActive(false);
                else
                    state.gameObject.SetActive(true);
            }
        } 
    }
}