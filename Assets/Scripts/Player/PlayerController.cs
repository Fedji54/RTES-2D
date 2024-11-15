using UnityEngine;
using UnityEngine.InputSystem;

namespace WinterUniverse
{
    public class PlayerController : PawnController
    {
        private Vector3 _cursorPosition;
        private Vector3 _clickPosition;

        public void OnCursorPosition(InputValue value)
        {
            _cursorPosition = value.Get<Vector2>();
        }

        public void OnMouseClick()
        {
            _clickPosition = Camera.main.ScreenToWorldPoint(_cursorPosition);
            RaycastHit2D hit = Physics2D.Raycast(_clickPosition, Vector3.forward, 15f);
            if (hit.collider == null)
            {
                _clickPosition.z = 0f;
                _pawnLocomotion.SetDestination(_clickPosition, 0.25f);
            }
        }

        public void OnInteract()
        {
            _clickPosition = Camera.main.ScreenToWorldPoint(_cursorPosition);
            RaycastHit2D hit = Physics2D.Raycast(_clickPosition, Vector3.forward, 15f);
            if (hit.collider != null && hit.collider.TryGetComponent(out Interactable interactable))
            {
                _pawnLocomotion.SetDestination(interactable);
            }
        }
    }
}