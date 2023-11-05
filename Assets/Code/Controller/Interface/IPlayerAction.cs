using UnityEngine;

namespace Code.Controller.Interface
{
    public interface IPlayerAction
    {
        protected internal void Walk(Vector2 wasd)
        {
        }

        protected internal void Run()
        {
        }

        //protected internal void Jump(InputAction.CallbackContext obj) { }
        protected internal void Dash()
        {
        }
    }
}