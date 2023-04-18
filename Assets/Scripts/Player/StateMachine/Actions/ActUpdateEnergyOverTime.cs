using System;
using Player.EnergySystem;
using UnityEngine;

namespace Player.StateMachine.Actions {
    public class ActUpdateEnergyOverTime : MonoBehaviour {
        [SerializeField] private float _deltaTimeInSeconds;
        [SerializeField] private int _deltaEnergyOverTime;
        private EnergyManager _energyManager;

        private void Awake() {
            _energyManager = GetComponentInParent<EnergyManager>();
        }

        public void OnEnable() {
            _energyManager.StopAllCoroutines();
            _energyManager.StartUpdateEnergyCO(_deltaEnergyOverTime, _deltaTimeInSeconds);
        }

        private void OnDisable() {
            _energyManager.StopAllCoroutines();
        }
    }
}