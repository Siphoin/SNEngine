using Cysharp.Threading.Tasks;
using DG.Tweening;
using SNEngine.Animations;
using SNEngine.Services;
using UnityEngine;

namespace SNEngine.BackgroundSystem.Animations
{
    public class SetColorBackgroundNode : ChangeColorNode
    {
        protected override void ChangeColor(Color color, float duration, Ease ease)
        {
            SetColor(color, duration, ease).Forget();
        }

        private async UniTask SetColor(Color color, float duration, Ease ease)
        {
            var backgroundService = NovelGame.GetService<BackgroundService>();

            await backgroundService.ChangeColor(color, duration, ease);

            StopTask();
        }
    }
}
