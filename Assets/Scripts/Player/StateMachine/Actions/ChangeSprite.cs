using UnityEngine;

namespace Player.StateMachine.Actions {
    public class ChangeSprite : MonoBehaviour {
        private SpriteRenderer _spriteRenderer;
        
        private void Awake() {
            
            if(transform.parent != null)
                _spriteRenderer = transform.parent.parent.GetComponentInChildren<SpriteRenderer>();
            else
                _spriteRenderer = GetComponent<SpriteRenderer>();
        }

        public void SetNewSprite(Sprite newSprite) {
            Awake();
            _spriteRenderer.sprite = newSprite;
        } 
    }
}