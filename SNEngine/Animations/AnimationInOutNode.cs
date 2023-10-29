using DG.Tweening;
using UnityEngine;

namespace SNEngine.Animations
{
    public abstract class AnimationInOutNode : AnimationNode
    {
        [SerializeField] private AnimationBehaviourType _executeType;
        protected override void Play(float duration, Ease ease)
        {
           Play(duration, _executeType, ease);
        }

        protected abstract void Play (float duration, AnimationBehaviourType type, Ease ease);
    }

    public abstract class AnimationInOutNode<T> : AnimationNode<T>
    {
        [SerializeField] private AnimationBehaviourType _executeType;

        protected override void Play(T target, float duration, Ease ease)
        {
            Play(target, duration, _executeType, ease);
        }

        protected abstract void Play(T target, float duration, AnimationBehaviourType type, Ease ease);
    }
}


