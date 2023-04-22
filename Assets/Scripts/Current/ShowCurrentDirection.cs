using UnityEngine;

namespace Current {
    public class ShowCurrentDirection : MonoBehaviour {
        private AreaEffector2D _effector2D;
        private BoxCollider2D _collider2D;

        private void OnDrawGizmos() {
            if (_effector2D == null || _collider2D == null) {
                _effector2D = GetComponentInParent<AreaEffector2D>();
                _collider2D = _effector2D.GetComponent<BoxCollider2D>();
            }
            transform.localRotation = Quaternion.Euler(0,0,_effector2D.forceAngle - 90);
            
            
        }
    }
}