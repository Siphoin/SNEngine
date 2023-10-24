using Cysharp.Threading.Tasks;
using DG.Tweening;
using SNEngine.Animations;
using SNEngine.Services;
using UnityEngine;

namespace SNEngine.BackgroundSystem.Animations
{
    public class ParalaxBackgroundNode : AsyncBackgroundNode
    {
        [SerializeField] private Direction _direction;
        protected override void Play(float duration, Ease ease)
        {
            Move(duration, ease).Forget();
        }

        private async UniTask Move (float duration, Ease ease)
        {
            var backgroundService = NovelGame.GetService<BackgroundService>();

            await backgroundService.Move(_direction, duration, ease);
        }
    }
}
