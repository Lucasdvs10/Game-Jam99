using Player.EnergySystem;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
    [RequireComponent(typeof(Slider))]
    public class EnergyBar : MonoBehaviour {
        [SerializeField] private SOSingletonInt _maxValueSingleton;
        [SerializeField] private SOSingletonInt _currentValueSingleton;
        private Slider _slider;

        private void Awake() {
            _slider = GetComponent<Slider>();
        }

        private void Start() {
            _currentValueSingleton.SubscribeOnEvent(UpdateBarValue);
            
            _slider.maxValue = _maxValueSingleton.Value;
            _slider.value = _currentValueSingleton.Value;
        }

        public void UpdateBarValue() {
            _slider.value = _currentValueSingleton.Value;
        }
    }
}