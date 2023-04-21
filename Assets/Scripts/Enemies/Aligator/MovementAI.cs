using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace Enemies.Aligator {
    [RequireComponent(typeof(NavMeshAgent))]
    public class MovementAI : MonoBehaviour {
        private NavMeshAgent _agent;
        private Vector3 _playerPosition;
        private bool _isChasingPlayer;
        public bool ChasePlayerOnStart;


        [Header("Modo normal")] 
        [SerializeField][Range(1,10)] private float _normalSpeed;
        
        [Header("Modo sprint")] 
        [SerializeField] private float _sprintDurationInSeconds;
        [SerializeField][Range(1,10)] private float _sprintSpeed;
        
        private void Awake() {
            _agent = GetComponent<NavMeshAgent>();
            _agent.updateRotation = false;
            _agent.updateUpAxis = false;

            _agent.speed = _normalSpeed;

            _isChasingPlayer = ChasePlayerOnStart;
        }

        [ContextMenu("Mover até a posicao atual do player")]
        public void GoToPlayerPosition() {
            GetPlayerPosition();
            _agent.SetDestination(_playerPosition);
        }

        private void Update() {
            if(_isChasingPlayer)
                GoToPlayerPosition();
        }

        [ContextMenu("Ativar modo sprint")]
        public void StartActivateSprintCO() {
            StartCoroutine(ActivateSprintForSomeSecondsCO(_sprintDurationInSeconds));
        }
        
        private IEnumerator ActivateSprintForSomeSecondsCO(float durationInSeconds) {
            _agent.speed = _sprintSpeed;
            yield return new WaitForSeconds(durationInSeconds);
            _agent.speed = _normalSpeed;
        }
        
        private void GetPlayerPosition() {
            _playerPosition = GameObject.FindWithTag("Player").transform.position;
        }

        public void SetIsChasinPlayerFlag(bool newValue) => _isChasingPlayer = newValue;
    }
}