using DG.Tweening;
using UnityEngine;

namespace SNEngine.Animations
{
    public abstract class ChangeColorNode : AnimationNode
    {
        [Input(connectionType = ConnectionType.Override), SerializeField] private Color _color = Color.white;

        protected override void Play(float duration, Ease ease)
        {
            Color color = _color;

            var input = GetInputPort(nameof(_color));

            if (input.Connection != null)
            {
                color = GetDataFromPort<Color>(nameof(_color));
            }

            ChangeColor(color, duration, ease);
        }

        protected abstract void ChangeColor(Color color, float duration, Ease ease);


    }

    public abstract class ChangeColorNode<T> : AnimationNode<T>
    {
        [Input(connectionType = ConnectionType.Override), SerializeField] private Color _color = Color.white;

        protected override void Play(T target, float duration, Ease ease)
        {
            Color color = _color;

            var input = GetInputPort(nameof(_color));

            if (input.Connection != null)
            {
                color = GetDataFromPort<Color>(nameof(_color));
            }

            ChangeColor(target, color, duration, ease);
        }

        protected abstract void ChangeColor(T target, Color color, float duration, Ease ease);


    }
}
