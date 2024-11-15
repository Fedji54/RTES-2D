using UnityEngine;

namespace WinterUniverse
{
    [RequireComponent(typeof(Rigidbody2D))]
    public class PawnLocomotion : MonoBehaviour
    {
        [SerializeField] private float _moveSpeed = 4f;

        private PawnController _pawn;
        private Rigidbody2D _rb;
        private Interactable _interactable;
        private Vector3 _moveDirection;
        private Vector3 _destination;
        private float _stopDistance;
        private bool _reachedDestination;
        private bool _isFacingRight = true;

        public void Initialize(PawnController pawn)
        {
            _pawn = pawn;
            _rb = GetComponent<Rigidbody2D>();
        }

        public void SetDestination(Vector3 position, float stopDistance)
        {
            _interactable = null;
            _stopDistance = stopDistance;
            _destination = position;
            _reachedDestination = false;
            _pawn.PawnAnimator.SetBool("IsMoving", true);
        }

        public void SetDestination(Interactable interactable)
        {
            _interactable = interactable;
            _stopDistance = _interactable.StopDistance;
            _destination = _interactable.InteractionPoint.position;
            _reachedDestination = false;
            _pawn.PawnAnimator.SetBool("IsMoving", true);
        }

        public void OnFixedUpdate()
        {
            if (!_reachedDestination)
            {
                if (_interactable != null)
                {
                    _destination = _interactable.InteractionPoint.position;
                }
                _moveDirection = _destination - transform.position;
                if (_moveDirection.magnitude > _stopDistance)
                {
                    if (_isFacingRight && _moveDirection.x < 0f)
                    {
                        _isFacingRight = false;
                        transform.localScale = new(-1f, 1f, 1f);
                    }
                    else if (!_isFacingRight && _moveDirection.x > 0f)
                    {
                        _isFacingRight = true;
                        transform.localScale = new(1f, 1f, 1f);
                    }
                    _rb.linearVelocity = _moveDirection.normalized * _moveSpeed;
                }
                else
                {
                    _rb.linearVelocity = Vector2.zero;
                    _reachedDestination = true;
                    _pawn.PawnAnimator.SetBool("IsMoving", false);
                    if (_interactable != null)
                    {
                        if (_interactable.CanInteract(_pawn))
                        {
                            _interactable.Interact(_pawn);
                        }
                        _interactable = null;
                    }
                }
            }
        }
    }
}