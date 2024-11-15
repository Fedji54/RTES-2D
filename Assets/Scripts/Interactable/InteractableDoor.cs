using UnityEngine;

namespace WinterUniverse
{
    public class InteractableDoor : Interactable
    {
        public override void Interact(PawnController pawn)
        {
            Destroy(pawn.gameObject);
        }
    }
}