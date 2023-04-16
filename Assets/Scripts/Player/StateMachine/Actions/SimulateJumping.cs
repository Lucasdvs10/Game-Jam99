using UnityEngine;

namespace Player.StateMachine.Actions {
    public class SimulateJumping : MonoBehaviour {
        private void OnEnable() {
            transform.parent.parent.localScale *= 1.5f;
        }

        private void OnDisable() {
            transform.parent.parent.localScale /= 1.5f;
        }
    }
}