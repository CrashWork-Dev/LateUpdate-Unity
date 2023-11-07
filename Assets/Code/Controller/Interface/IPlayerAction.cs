using UnityEngine;
using UnityEngine.InputSystem;

namespace Code.Controller.Interface
{
    public interface IPlayerAction
    {
        protected internal void Walk(Vector2 wasd);

        protected internal void Run();
        
        protected internal void Dash();

        protected internal void Jump(InputAction.CallbackContext obj);
        protected internal void Attack(InputAction.CallbackContext obj);
        protected internal void ResetCollider();
    }
}