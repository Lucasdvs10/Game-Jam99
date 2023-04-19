using UnityEngine;

namespace Player.StateMachine.Actions {
    public class ChangeSprite : MonoBehaviour {
        private SpriteRenderer _spriteRenderer;
        
        private void Awake() {
            _spriteRenderer = transform.parent.parent.GetComponentInChildren<SpriteRenderer>();
        }

        public void SetNewSprite(Sprite newSprite) {
            Awake();
            _spriteRenderer.sprite = newSprite;
        } 
    }
}