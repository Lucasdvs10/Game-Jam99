using Player.EnergySystem;
using UnityEngine;

namespace Player.StateMachine.Actions {
    public class ChangeIntValueOnStateEnter : MonoBehaviour {
        [SerializeField] private int deltaValueOnEnable;
        [SerializeField] private SOSingletonInt _singletonToChange;
        
        private void OnEnable() {
            _singletonToChange.ChangeValue(_singletonToChange.Value + deltaValueOnEnable);
        }
    }
}