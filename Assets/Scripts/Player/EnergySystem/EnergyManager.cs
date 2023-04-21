using System.Collections;
using UnityEngine;

namespace Player.EnergySystem {
    public class EnergyManager : MonoBehaviour {
        [SerializeField] private int _maxEnergy;
        [SerializeField] private int _initialEnergy;
        [SerializeField] private SOSingletonInt _maxEnergySingleton;
        [SerializeField] private SOSingletonInt _currentEnergySingleton;
        private int _currentEnergy;

        private void Awake() {
            CurrentEnergy = _initialEnergy;
            _maxEnergySingleton.Value = _maxEnergy;
            _currentEnergySingleton.Value = CurrentEnergy;
        }
        public void StartUpdateEnergyCO(int deltaEnergy, float updateDelayInSeconds) {
            StartCoroutine(UpdateCurrentEnergyOverTimeCO(deltaEnergy, updateDelayInSeconds));
        }
        
        public IEnumerator UpdateCurrentEnergyOverTimeCO(int deltaEnergy, float deltaTimeInSeconds) {
            while (true) {
                yield return new WaitForSeconds(deltaTimeInSeconds);
                CurrentEnergy += deltaEnergy;
            }
        }

        public int CurrentEnergy {
            get => _currentEnergy;
            set {
                _currentEnergy = Mathf.Clamp(value, 0, _maxEnergy);
                _currentEnergySingleton.ChangeValue(Mathf.Clamp(value, 0, _maxEnergy));
            }
        }
    }
}