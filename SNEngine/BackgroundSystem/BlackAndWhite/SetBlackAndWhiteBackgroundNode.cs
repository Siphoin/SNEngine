using Cysharp.Threading.Tasks;
using DG.Tweening;
using SNEngine.Services;
using System;
using UnityEngine;

namespace SNEngine.BackgroundSystem.Animations.BlackAndWhite
{
    public class SetBlackAndWhiteBackgroundNode : AsyncBackgroundNode
    {
        [Input(connectionType = ConnectionType.Override), Range(0, 1), SerializeField] private float _value;

        protected override void Play(float duration, Ease ease)
        {
            float value = _value;

            var input = GetInputPort(nameof(_value));

            if (input.Connection != null)
            {
                value = GetDataFromPort<float>(nameof(_value));
            }

            BlackAndWhite(value, duration, ease).Forget();


        }
        private async UniTask BlackAndWhite(float value, float duration, Ease ease)
        {
            var backgroundService = NovelGame.GetService<BackgroundService>();

            await backgroundService.ToBlackAndWhite(duration, value, ease);

            StopTask();
        }
    }
}
