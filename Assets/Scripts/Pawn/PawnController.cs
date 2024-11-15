using UnityEngine;

namespace WinterUniverse
{
    public abstract class PawnController : MonoBehaviour
    {
        protected PawnAnimator _pawnAnimator;
        protected PawnCombat _pawnCombat;
        protected PawnLocomotion _pawnLocomotion;

        public PawnAnimator PawnAnimator => _pawnAnimator;
        public PawnCombat PawnCombat => _pawnCombat;
        public PawnLocomotion PawnLocomotion => _pawnLocomotion;

        protected virtual void Awake()
        {
            GetPawnComponents();
            InitializeComponents();
        }

        protected virtual void GetPawnComponents()
        {
            _pawnAnimator = GetComponent<PawnAnimator>();
            _pawnCombat = GetComponent<PawnCombat>();
            _pawnLocomotion = GetComponent<PawnLocomotion>();
        }

        protected virtual void InitializeComponents()
        {
            _pawnAnimator.Initialize(this);
            _pawnCombat.Initialize(this);
            _pawnLocomotion.Initialize(this);
        }

        protected virtual void FixedUpdate()
        {
            _pawnLocomotion.OnFixedUpdate();
        }
    }
}