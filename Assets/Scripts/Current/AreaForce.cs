using UnityEngine;

namespace Current {
    public class AreaForce : MonoBehaviour {
        private void OnTriggerExit2D(Collider2D other) {
            if (other.CompareTag("Player")) {
                var playerMovement = other.GetComponentInChildren<PlayerMovement.PlayerMovement>();
                playerMovement.MovePlayerToDirectionBuffer();
            }
        }
    }
}