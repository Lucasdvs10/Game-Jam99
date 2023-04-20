using UnityEngine;
using UnityEngine.AI;

namespace Enemies.Aligator {
    [RequireComponent(typeof(NavMeshAgent))]
    public class MovementAI : MonoBehaviour {
        private NavMeshAgent _agent;
        private Vector3 _playerPosition;
        
        private void Awake() {
            _agent = GetComponent<NavMeshAgent>();
        }

        [ContextMenu("Mover até a posicao atual do player")]
        public void GoToPlayerPosition() {
            GetPlayerPosition();
            _agent.SetDestination(_playerPosition);
        }

        private void GetPlayerPosition() {
            _playerPosition = GameObject.FindWithTag("Player").transform.position;
        }
    }
}