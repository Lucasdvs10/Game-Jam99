using System;
using System.Collections;
using UnityEngine;

namespace DefaultNamespace {
    public class PlaySoundEffect : MonoBehaviour {
        [SerializeField] private AudioClip[] _audioClipsArray;
        [SerializeField] private AudioSource _audioSource;
        
        private int _currentIndex;
        
        public void StartPlayAudiosLoopCO() {
            StopPlayAudiosCO();
            StartCoroutine(PlayAudiosLoop());
        }

        public void StopPlayAudiosCO() {
            StopAllCoroutines();
        }
        
        private IEnumerator PlayAudiosLoop() {
            while (true) {
                PlayNextAudioInArray();
                yield return new WaitForSeconds(_audioSource.clip.length);
            }
        }
        
        public void PlayNextAudioInArray() {
            CurrentIndex++;
            _audioSource.clip = _audioClipsArray[_currentIndex];
            _audioSource.Play();
        }


        public int CurrentIndex {
            get => _currentIndex;
            set {
                if (value >= _audioClipsArray.Length)
                    _currentIndex = 0;
                else {
                    _currentIndex = value;
                }
            }
        }
    }
}