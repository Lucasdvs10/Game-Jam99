using UnityEngine;

namespace Player.StateMachine.Actions {
    public class ChangeSpriteLayerPriority : MonoBehaviour {
        private SpriteRenderer _spriteRenderer;

        private void Awake() {
            _spriteRenderer = transform.parent.parent.GetComponentInChildren<SpriteRenderer>();
        }

        public void SetPriorityValueOnLayers(int newValue) {
            Awake();
            _spriteRenderer.sortingOrder = newValue;  
        } 
    }
}