using Player.StateMachine;
using Player.StateMachine.Actions;
using UnityEngine;

namespace Enemies.Bird.State_Machine.Actions {
    public class FishAttacherToBird : MonoBehaviour {
        private void OnDisable() {
            var nextState = FindObjectOfType<GotByBirdStateTag>(true)?.transform;
            nextState?.GetComponent<StateTransitionBlocker>().UnblockStateTransitionEvent.RemoveListener(UnleashFish);
        }

        public void GetFish() {
            var gameobj = GameObject.FindWithTag("Player");

            gameobj.transform.position = transform.position;
            gameobj.GetComponentInChildren<PlayerMovement.PlayerMovement>().SetFollowBirdFlag(true);
            var stateManager = gameobj.GetComponentInChildren<StateManager>();
            var nextState = stateManager.GetComponentInChildren<GotByBirdStateTag>(true).transform;
            stateManager.ChangeState(nextState);
            
            nextState.GetComponent<StateTransitionBlocker>().UnblockStateTransitionEvent.AddListener(UnleashFish);
        }

        public void UnleashFish() {
             FindObjectOfType<PlayerMovement.PlayerMovement>()?.SetFollowBirdFlag(false);           
        }
    }
}