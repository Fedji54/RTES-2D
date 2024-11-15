using UnityEngine;

namespace WinterUniverse
{
    public abstract class Interactable : MonoBehaviour
    {
        [SerializeField] private Transform _interactionPoint;
        [SerializeField] private float _stopDistance = 0.1f;

        public Transform InteractionPoint => _interactionPoint;
        public float StopDistance => _stopDistance;

        public virtual bool CanInteract(PawnController pawn)
        {
            return true;
        }

        public abstract void Interact(PawnController pawn);
    }
}