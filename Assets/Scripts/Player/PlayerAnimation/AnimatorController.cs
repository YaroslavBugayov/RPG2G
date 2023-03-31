using UnityEngine;

namespace Player.PlayerAnimation
{
    public class AnimatorController
    {
        private readonly Animator _animator;
        private Vector2 _movement;
        private float _movementSpeed;

        public AnimatorController(Animator animator)
        {
            _animator = animator;
        }

        public void SetValues(float horizontalDirection, float verticalDirection)
        {
            _movement = new Vector2(horizontalDirection, verticalDirection);
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