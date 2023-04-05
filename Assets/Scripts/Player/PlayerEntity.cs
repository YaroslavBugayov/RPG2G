using Core.Movement.Controller;
using Core.Movement.Data;
using Player.PlayerAnimation;
using StatsSystem;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
    public class PlayerEntity : MonoBehaviour
    {
        [SerializeField] private DirectionalMovementData _directionalMovementData;

        private Rigidbody2D _rigidbody;
        private Animator _animator;
        private DirectionalMover _directionalMover;
        private AnimatorController _animatorController;
    
        public void Initialize(IStatValueGiver statValueGiver)
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _directionalMover = new DirectionalMover(_rigidbody, _directionalMovementData, statValueGiver);
            _animatorController = new AnimatorController(_animator);
        }

        public void Use()
        {
            
        }

        public void Move(float horizontalDirection, float verticalDirection)
        {
            _directionalMover.Move(horizontalDirection, verticalDirection);
            _animatorController.SetValues(horizontalDirection, verticalDirection);
        }

    }
}
