using Cysharp.Threading.Tasks;
using DG.Tweening;
using SNEngine.Animations;
using SNEngine.Services;

namespace SNEngine.BackgroundSystem.Animations.Illumination
{
    public class IlluminationBackgroundInOutNode : AnimationInOutNode
    {
        protected override void Play(float duration, AnimationBehaviourType type, Ease ease)
        {
            Illuminate(duration, type, ease).Forget();
        }

        private async UniTask Illuminate(float duration, AnimationBehaviourType type, Ease ease)
        {
            var backgroundService = NovelGame.GetService<BackgroundService>();

            await backgroundService.Illuminate(duration, type, ease);

            StopTask();
        }
    }
}
