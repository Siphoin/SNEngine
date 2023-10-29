using Cysharp.Threading.Tasks;
using DG.Tweening;
using SNEngine.Animations;
using SNEngine.Attributes;
using SNEngine.Services;
using UnityEngine;

namespace SNEngine.BackgroundSystem.Animations
{
    public class DissolveBackgroundNode : DissolveNode
    {
        [Space]

        [SerializeField, LeftToggle, Input(connectionType = ConnectionType.Override)] private bool _useTransition;
        protected override void Play(float duration, AnimationBehaviourType type, Ease ease, Texture2D texture)
        {
            bool useTransliton = _useTransition;

            var input = GetInputPort(nameof(_useTransition));

            if (input.Connection != null)
            {
                useTransliton = GetDataFromPort<bool>(nameof(_useTransition));
            }

            Dissolve(duration, type, ease, texture, _useTransition).Forget();
        }

        private async UniTask Dissolve(float duration, AnimationBehaviourType type, Ease ease, Texture2D texture, bool useTransition)
        {
            var service = NovelGame.GetService<BackgroundService>();

            await service.Dissolve(duration, type, ease, texture, useTransition);

            StopTask();
        }
    }
}
