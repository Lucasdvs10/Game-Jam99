using System;
using Player.EnergySystem;
using UnityEngine;
using UnityEngine.UI;

namespace UI {
    [RequireComponent(typeof(Slider))]
    public class EnergyBar : MonoBehaviour {
        [SerializeField] private SOSingletonInt _maxValueSingleton;
        [SerializeField] private SOSingletonInt _currentValueSingleton;
        [SerializeField] private Image _barImage;

        private void Start() {
            _currentValueSingleton.SubscribeOnEvent(UpdateBarValue);
            
            UpdateBarValue();
        }

        private void OnDisable() {
            _currentValueSingleton.UnsubscribeOnEvent(UpdateBarValue);
        }

        public void UpdateBarValue() {
            _barImage.fillAmount = ((float)_currentValueSingleton.Value / (float)_maxValueSingleton.Value);
            print( ((float)_currentValueSingleton.Value / (float)_maxValueSingleton.Value));
        }
    }
}