using Cysharp.Threading.Tasks;
using DG.Tweening;
using SNEngine.Services;
using UnityEngine;

namespace SNEngine.BackgroundSystem.Animations.Celia
{
    public class CeliaBackgroundNode : AsyncBackgroundNode
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

            Celia(value, duration, ease).Forget();


        }

        private async UniTask Celia(float value, float duration, Ease ease)
        {
            var backgroundService = NovelGame.GetService<BackgroundService>();

            await backgroundService.Celia(value, duration, ease);

            StopTask();
        }
    }
}
