using Cysharp.Threading.Tasks;
using DG.Tweening;
using SNEngine.Animations;
using SNEngine.Services;

namespace SNEngine.BackgroundSystem.Animations.Fade
{
    public class FadeBackgroundNodeInOutNode : AnimationInOutNode
    {
        protected override void Play(float duration, AnimationBehaviourType type, Ease ease)
        {
            Fade(duration, type, ease).Forget();
        }

        private async UniTask Fade(float duration, AnimationBehaviourType type, Ease ease)
        {
            var backgroundService = NovelGame.GetService<BackgroundService>();

            await backgroundService.Fade(duration, type, ease);

            StopTask();
        }
    }
}
