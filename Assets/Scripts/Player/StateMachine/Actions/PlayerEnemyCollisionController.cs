using UnityEngine;

namespace Player.StateMachine.Actions {
    public class PlayerEnemyCollisionController : MonoBehaviour {
        public void SwitchPlayerEnemyCollision(bool newValue) {
            if (newValue)
                transform.parent.parent.gameObject.layer = 7;
            else
                transform.parent.parent.gameObject.layer = 8;
        }
        
    }
}