using Core.Movement.Controller;
using Core.Movement.Data;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
    public class PlayerEntity : MonoBehaviour
    {
        [SerializeField] private DirectionalMovementData _directionalMovementData;
        
        private Vector2 _movement;
        private float _movementSpeed;
        
        private Rigidbody2D _rigidbody;
        private Animator _animator;
        private DirectionalMover _directionalMover;
    
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
            _directionalMover = new DirectionalMover(_rigidbody, _directionalMovementData);
        }

        private void Update()
        {
            SetAnimation();
        }

        public void Use()
        {
            
        }

        public void Move(float horizontalDirection, float verticalDirection) =>
            _directionalMover.Move(horizontalDirection, verticalDirection);

        private void SetAnimation()
        {
            _movementSpeed = Mathf.Clamp(_movement.magnitude, 0.0f, 1.0f);
            if (_movement != Vector2.zero)
            {
                _animator.SetFloat("Horizontal", _movement.x);
                _animator.SetFloat("Vertical", _movement.y);   
            }
            _animator.SetFloat("Speed", _movementSpeed);
        }
    }
}
