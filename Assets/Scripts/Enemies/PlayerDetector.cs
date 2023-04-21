using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace Enemies {
    public class PlayerDetector : MonoBehaviour {
        public LayerMask LayerMask;
        public float DelayInSecondsBetweenPlayerEnterAndPlayerQuit;
        public UnityEvent PlayerEnteredAreaEvent;
        public UnityEvent PlayerIsInAreaAfterDelayEvent;
        public UnityEvent PlayerQuittedAreaEvent;
        private BoxCollider2D _boxCollider;

        private void OnTriggerEnter2D(Collider2D col) {
            if (col.CompareTag("Player") && (LayerMask.value & 1 << col.gameObject.layer) > 0) {
                StartCoroutine(DetectPlayerCO(DelayInSecondsBetweenPlayerEnterAndPlayerQuit));
            }
        }

        private void OnTriggerExit2D(Collider2D other) {
            if (other.CompareTag("Player") && (LayerMask.value & 1 << other.gameObject.layer) > 0) {
                StopAllCoroutines();
                PlayerQuittedAreaEvent.Invoke();
                // print("Player saiu da área");
            }
        }

        private IEnumerator DetectPlayerCO(float delayInSeconds) {
            PlayerEnteredAreaEvent.Invoke();
            // print("Player entrou");
            
            yield return new WaitForSeconds(delayInSeconds);
            
            // print("Player ainda está na área mesmo depois do delay");
            PlayerIsInAreaAfterDelayEvent.Invoke();
        }
        
    }
}