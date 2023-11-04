using System.Drawing.Drawing2D;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;

namespace Code.Controller.PlayerAction
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