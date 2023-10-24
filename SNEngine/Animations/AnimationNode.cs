using DG.Tweening;
using SiphoinUnityHelpers.XNodeExtensions.AsyncNodes;
using UnityEngine;

namespace SNEngine.Animations
{
    public abstract class AnimationNode : AsyncNode
    {

        [Input(connectionType = ConnectionType.Override), SerializeField] private bool _wait;

        [Input(connectionType = ConnectionType.Override), SerializeField, Min(0)] private float _duration;

        [SerializeField] private Ease _ease = Ease.Linear;

        protected Ease Ease => _ease;

        public override void Execute()
        {
            bool wait = _wait;

            float duration = _duration;

            if (GetInputPort(nameof(_wait)).Connection != null)
            {
                wait = GetDataFromPort<bool>(nameof(_wait));
            }

            if (GetInputPort(nameof(_duration)).Connection != null)
            {
                duration = GetDataFromPort<float>(nameof(_duration));
            }

            if (wait)
            {
                base.Execute();
            }

            Play(duration, _ease);

        }

        protected abstract void Play(float duration, Ease ease);
    }


    public abstract class AnimationNode<T> : AnimationNode
    {
        [Space]

        [Input(connectionType = ConnectionType.Override), SerializeField] private T _target;

        protected abstract void Play(T target, float duration, Ease ease);

        protected override void Play(float duration, Ease ease)
        {
            T target = _target;

            var input = GetInputPort(nameof(_target));

            if (input.Connection != null)
            {
                target = GetDataFromPort<T>(nameof(_target));
            }

            Play(target, duration, ease);
        }
    }
}
