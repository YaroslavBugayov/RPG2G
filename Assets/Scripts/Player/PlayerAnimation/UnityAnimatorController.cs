using System;
using UnityEngine;

namespace Player
{
    [RequireComponent(typeof(Animator))]
    public class UnityAnimatorController : AnimatorController
    {
        private Animator _animator;

        private void Start() => _animator = GetComponent<Animator>();
        
        
    }
}