using UnityEngine;

namespace WinterUniverse
{
    [RequireComponent(typeof(Animator))]
    public class PawnAnimator : MonoBehaviour
    {
        private PawnController _pawn;
        private Animator _animator;

        public void Initialize(PawnController pawn)
        {
            _pawn = pawn;
            _animator = GetComponent<Animator>();
        }

        public void SetFloat(string name, float value)
        {
            _animator.SetFloat(name, value);
        }

        public void SetBool(string name, bool value)
        {
            _animator.SetBool(name, value);
        }

        public void SetTrigger(string name)
        {
            _animator.SetTrigger(name);
        }
    }
}