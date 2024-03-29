﻿using UnityEngine;
using UnityEngine.UI;

namespace UI {
    public class MuteButton : MonoBehaviour {
        private Toggle _toggleButton;
        

        private void Awake() {
            _toggleButton = GetComponent<Toggle>();
        }

        public void ToggleMuteButon(AudioListener audioListener) {
            _toggleButton.isOn = !_toggleButton.isOn;
            ToggleAudioListener(audioListener);
        }

        public void ToggleAudioListener(AudioListener audioListener) {
            audioListener.enabled = !_toggleButton.isOn;
        }
    }
}