using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Rigidbody2D), typeof(Animator))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float _speed;

        private Vector2 _movement;
        private float _movementSpeed;
        
        private Rigidbody2D _rigidbody;
        private Animator _animator;
    
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody2D>();
            _animator = GetComponent<Animator>();
        }

        private void Update()
        {
            SetAnimation();
        }

        private void FixedUpdate()
        {
            Move();
        }

        public void ProcessInputs(float directionX, float directionY)
        {
            _movement = new Vector2(directionX, directionY);
            _movementSpeed = Mathf.Clamp(_movement.magnitude, 0.0f, 1.0f);
        }

        private void Move()
        {
            _rigidbody.MovePosition(_rigidbody.position + _movement * (_speed * Time.fixedDeltaTime));
        }

        private void SetAnimation()
        {
            if (_movement != Vector2.zero)
            {
                _animator.SetFloat("Horizontal", _movement.x);
                _animator.SetFloat("Vertical", _movement.y);   
            }
            _animator.SetFloat("Speed", _movementSpeed);
        }
    }
}
