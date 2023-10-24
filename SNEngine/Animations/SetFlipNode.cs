using SiphoinUnityHelpers.XNodeExtensions;
using UnityEngine;

namespace SNEngine.Animations
{
    public abstract class SetFlipNode : BaseNodeInteraction
    {
        [SerializeField] private FlipType _flipType = FlipType.X;

        public override void Execute()
        {
            SetFlip(_flipType);
        }

        protected abstract void SetFlip(FlipType flipType);
    }

    public abstract class SetFlipNode<T> : SetFlipNode
    {
        [Input(connectionType = ConnectionType.Override), SerializeField] private T _target;

        protected override void SetFlip(FlipType flipType)
        {
            T target = _target;

            var input = GetInputPort(nameof(_target));

            if (input.Connection != null)
            {
                target = GetDataFromPort<T>(nameof(_target));
            }

            SetFlip(target, flipType);
        }

        protected abstract void SetFlip(T target, FlipType flipType);
    }
}
