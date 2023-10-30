using Cysharp.Threading.Tasks;
using DG.Tweening;
using SNEngine.Animations;
using SNEngine.Services;

namespace SNEngine.BackgroundSystem.Animations.BlackAndWhite
{
    public class SetBlackAndWhiteBackgroundInOutNode : AnimationInOutNode
    {
        protected override void Play(float duration, AnimationBehaviourType type, Ease ease)
        {
            BlackAndWhite(duration, type, ease).Forget();
        }

        private async UniTask BlackAndWhite(float duration, AnimationBehaviourType type, Ease ease)
        {
            var backgroundService = NovelGame.GetService<BackgroundService>();

            await backgroundService.BlackAndWhite(duration, type, ease);

            StopTask();
        }
    }
}
