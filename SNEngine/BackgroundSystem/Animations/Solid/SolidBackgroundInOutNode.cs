using Cysharp.Threading.Tasks;
using DG.Tweening;
using SNEngine.Animations;
using SNEngine.Services;

namespace SNEngine.BackgroundSystem.Animations.Solid
{
    public class SolidBackgroundInOutNode : AnimationInOutNode
    {
        protected override void Play(float duration, AnimationBehaviourType type, Ease ease)
        {
            Solid(duration, type, ease).Forget();
        }

        private async UniTask Solid(float duration, AnimationBehaviourType type, Ease ease)
        {
            var backgroundService = NovelGame.GetService<BackgroundService>();

            await backgroundService.Solid(duration, type, ease);

            StopTask();
        }
    }
}
