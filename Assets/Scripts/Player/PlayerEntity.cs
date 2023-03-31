using Core.Movement.Controller;
using Core.Movement.Data;
using Player.PlayerAnimation;
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
        private UnityAnimatorController _animatorController;
    
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _directionalMover = new DirectionalMover(_rigidbody, _directionalMovementData);
            _animatorController = new UnityAnimatorController();
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
