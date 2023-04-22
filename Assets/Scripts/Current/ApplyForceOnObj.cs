using UnityEngine;

namespace Current {
    [RequireComponent(typeof(Rigidbody2D))]
    public class ApplyForceOnObj : MonoBehaviour {
        private Vector3 _vectDirection;
        private GameObject _directionReference;
        private Rigidbody2D _rgb;
        public bool ApplyForceOnAwake = true;

        [SerializeField] float _forceMagnitude;
        
        private void OnDrawGizmos() {
            if (transform.childCount < 1) {
                _directionReference = new GameObject("Direcao Correnteza");
                _directionReference.transform.position = transform.position;
                _directionReference.transform.parent = transform;
            }
            
            // if(Ximbas == null) return;
            
            // Gizmos.DrawLine(transform.position, Ximbas.transform.position);
            // Gizmos.DrawLine(Ximbas.transform.position,  Ximbas.transform.localToWorldMatrix * new Vector3(1,1,0));
            // Gizmos.DrawLine(Ximbas.transform.position, Ximbas.transform.localToWorldMatrix * new Vector3(1.5f,-1,0));
        }

        private void Awake() {
            if (_directionReference == null)
                _directionReference = transform.GetChild(0).gameObject;
            
            _vectDirection = (_directionReference.transform.position - transform.position).normalized;
            _rgb = GetComponent<Rigidbody2D>();
            _rgb.gravityScale = 0f;
            _rgb.freezeRotation = true;
        }

        private void Start() {
            if(ApplyForceOnAwake)
                ApplyCurrentForce();
        }

        [ContextMenu("Aplicar Forca")]
        public void ApplyCurrentForce() {
            _rgb.AddForce(_vectDirection * _forceMagnitude, ForceMode2D.Impulse);
        }
        
    }
}