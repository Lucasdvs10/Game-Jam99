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
        public UnityEvent CtrlButtonPressedEvent;
        public UnityEvent CtrlButtonReleasedEvent;
        public UnityEvent MButtonPressedEvent;
        public UnityEvent MButtonReleasedEvent;
        
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
        
        public void ReadHoldBreathKey(InputAction.CallbackContext ctx) {
            if (ctx.performed)
                CtrlButtonPressedEvent.Invoke();
            if (ctx.canceled)
                CtrlButtonReleasedEvent.Invoke();
        }
        
        
        public void ReadToggleMuteKey(InputAction.CallbackContext ctx) {
            if (ctx.performed)
                MButtonPressedEvent.Invoke();
            if (ctx.canceled)
                MButtonReleasedEvent.Invoke();
        }
    }
}