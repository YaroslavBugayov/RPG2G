using UnityEngine;

namespace Player.PlayerAnimation
{
    [RequireComponent(typeof(Animator))]
    public class UnityAnimatorController : AnimatorController
    {
        private Animator _animator;
        private Vector2 _movement;
        private float _movementSpeed;

        private void Start() => _animator = GetComponent<Animator>();

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

        protected override void PlayAnimation(AnimationType animationType)
        {
            _animator.SetTrigger(nameof(AnimationType));
        }
    }
}