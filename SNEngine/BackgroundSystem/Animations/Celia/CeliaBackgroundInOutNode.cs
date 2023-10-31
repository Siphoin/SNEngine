using Cysharp.Threading.Tasks;
using DG.Tweening;
using SNEngine.Animations;
using SNEngine.Services;

namespace SNEngine.BackgroundSystem.Animations.Celia
{
    public class CeliaBackgroundInOutNode : AnimationInOutNode
    {
        protected override void Play(float duration, AnimationBehaviourType type, Ease ease)
        {
            Celia(duration, type, ease).Forget();
        }

        private async UniTask Celia(float duration, AnimationBehaviourType type, Ease ease)
        {
            var backgroundService = NovelGame.GetService<BackgroundService>();

            await backgroundService.Celia(duration, type, ease);

            StopTask();
        }
    }
}
