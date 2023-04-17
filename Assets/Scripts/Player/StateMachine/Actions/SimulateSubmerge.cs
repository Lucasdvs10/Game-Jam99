using System;
using UnityEngine;

namespace Player.StateMachine.Actions {
    public class SimulateSubmerge : MonoBehaviour {
        private SpriteRenderer _playerSpriteRenderer;

        private void Awake() {
            _playerSpriteRenderer = transform.parent.parent.GetComponentInChildren<SpriteRenderer>();
        }

        private void OnEnable() {
            transform.parent.parent.localScale /= 1.5f;
            _playerSpriteRenderer.color = Color.cyan;
        }

        private void OnDisable() {
            transform.parent.parent.localScale *= 1.5f;
            _playerSpriteRenderer.color = Color.white;
        }
    }
}