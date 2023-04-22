using System.Collections;
using UnityEngine;

namespace Player.EnergySystem {
    public class EnergyManager : MonoBehaviour {
        [SerializeField] private int _maxEnergy;
        [SerializeField] private int _initialEnergy;
        [SerializeField] private SOSingletonInt _maxEnergySingleton;
        [SerializeField] private SOSingletonInt _currentEnergySingleton;
        [SerializeField] private float _holdBreathDurationInSeconds;
        private float _currentBreathTimer;
        private bool _isHoldingBreath;
        private int _currentEnergy;

        private void Awake() {
            CurrentEnergy = _initialEnergy;
            _maxEnergySingleton.Value = _maxEnergy;
            _currentEnergySingleton.Value = CurrentEnergy;
        }
        public void StartUpdateEnergyCO(int deltaEnergy, float updateDelayInSeconds) {
            StartCoroutine(UpdateCurrentEnergyOverTimeCO(deltaEnergy, updateDelayInSeconds));
        }
        
        private IEnumerator UpdateCurrentEnergyOverTimeCO(int deltaEnergy, float deltaTimeInSeconds) {
            while (true) {
                yield return new WaitForSeconds(deltaTimeInSeconds);
                if (!_isHoldingBreath) {
                    CurrentEnergy += deltaEnergy;
                }
            }
        }

        private IEnumerator HoldingBreathTimer() {
            while (true) {
                _currentBreathTimer--;
                yield return new WaitForSeconds(1);

                if (_currentBreathTimer <= 0) {
                    SetHoldingBreathFlag(false);
                    break;
                }
            }
        }

        public void SetHoldingBreathFlag(bool newValue) {
          _isHoldingBreath = newValue;
          if (_isHoldingBreath) {
              _currentBreathTimer = _holdBreathDurationInSeconds;
              StartCoroutine(HoldingBreathTimer());
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