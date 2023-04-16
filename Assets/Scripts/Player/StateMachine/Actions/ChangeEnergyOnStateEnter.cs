using Player.EnergySystem;
using UnityEngine;

namespace Player.StateMachine.Actions {
    public class ChangeEnergyOnStateEnter : MonoBehaviour {
        [SerializeField] private int deltaValueOnEnable;
        private EnergyManager _energyManager;


        private void Awake() {
            _energyManager = FindObjectOfType<EnergyManager>();
        }

        private void OnEnable() {
            _energyManager.CurrentEnergy += deltaValueOnEnable;
        }
    }
}