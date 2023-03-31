using UnityEngine;

namespace Player.PlayerAnimation
{
    public abstract class AnimatorController : MonoBehaviour
    {
        protected abstract void PlayAnimation(AnimationType animationType);
    }
}