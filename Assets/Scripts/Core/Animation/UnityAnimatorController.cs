using UnityEngine;

namespace Core.Animation
{
    [RequireComponent(typeof(Animator))]
    public class UnityAnimatorController : AnimatorController
    {
        private Animator _animator;

        private void Start() => _animator = GetComponent<Animator>();
        
        
    }
}