using UnityEngine;

namespace Player.StateMachine.Actions {
    public class PlayerEnemyCollisionController : MonoBehaviour {
        public void SwitchPlayerEnemyCollision(int newLayerValue) {
                transform.parent.parent.gameObject.layer = newLayerValue;
        }
        
    }
}