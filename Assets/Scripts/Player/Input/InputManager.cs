using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace Input {
    public class InputManager : MonoBehaviour {
        public UnityEvent<Vector2> MovementButtonPressedEvent;
        public UnityEvent<Vector2> MovementButtonReleasedEvent;
        public UnityEvent JumpButtonPressedEvent;
        public UnityEvent JumpButtonReleasedEvent;
        public UnityEvent ShiftButtonPressedEvent;
        public UnityEvent ShiftButtonReleasedEvent;
        
        public void ReadMovementKeys(InputAction.CallbackContext ctx) {
            if (ctx.performed) {
                MovementButtonPressedEvent.Invoke(ctx.ReadValue<Vector2>());
            }
            
            if (ctx.canceled) {
                MovementButtonReleasedEvent.Invoke(ctx.ReadValue<Vector2>());
            }
        }

        public void ReadJumpKeys(InputAction.CallbackContext ctx) {
            if (ctx.performed) {
                JumpButtonPressedEvent.Invoke();
            }

            if (ctx.canceled) {
                JumpButtonReleasedEvent.Invoke();
            }
        }

        public void ReadSubmergeKeys(InputAction.CallbackContext ctx) {
            if (ctx.performed)
                ShiftButtonPressedEvent.Invoke();
            if (ctx.canceled)
                ShiftButtonReleasedEvent.Invoke();
        }
    }
}