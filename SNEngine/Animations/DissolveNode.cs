using DG.Tweening;
using UnityEngine;

namespace SNEngine.Animations
{
    public abstract class DissolveNode : AnimationInOutNode
    {
        [Space]

        [SerializeField, Input(connectionType = ConnectionType.Override)] private Texture2D _texture;

        protected override void Play(float duration, AnimationBehaviourType type, Ease ease)
        {
            var texture = _texture;

            var input = GetInputPort(nameof(_texture));

            if (input.Connection != null)
            {
                texture = GetDataFromPort<Texture2D>(nameof(_texture));
            }

            Play(duration, type, ease, texture);
        }

        protected abstract void Play(float duration, AnimationBehaviourType type, Ease ease, Texture2D texture);
    }

    public abstract class DissolveNode<T> : DissolveNode
    {
        [SerializeField] private T _target;

        protected override void Play(float duration, AnimationBehaviourType type, Ease ease, Texture2D texture)
        {
            Play(_target, duration, type, ease, texture);
        }

        protected abstract void Play(T target, float duration, AnimationBehaviourType type, Ease ease, Texture2D texture);



    }
}
