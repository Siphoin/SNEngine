using Cysharp.Threading.Tasks;
using DG.Tweening;
using SNEngine.Animations;
using SNEngine.BackgroundSystem;
using SNEngine.Extensions;
using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SNEngine.Services
{
    
    public class BackgroundService : IService, IResetable, IFadeable, IFlipable, IMovableByDirection, IChangeableColor
    {
        private IBackgroundRenderer _background;

        private IBackgroundRenderer _screenBackground;

        public void Initialize()
        {
            var background = Resources.Load<BackgroundRenderer>("Render/Background");

            var screenBackground = Resources.Load<ScreenBackgroundRender>("Render/ScreenBackground");

            var screenBackgroundPrefab = Object.Instantiate(screenBackground);

            screenBackgroundPrefab.name = screenBackground.name;

            Object.DontDestroyOnLoad(screenBackgroundPrefab);

            var backgroundPrefab = Object.Instantiate(background);

            backgroundPrefab.name = background.name;

            Object.DontDestroyOnLoad(backgroundPrefab);

            _background = backgroundPrefab;

            _screenBackground = screenBackground;
        }

        public void ResetState()
        {
            _background.ResetState();
        }

        public void Set (Sprite sprite)
        {
            _background.SetData(sprite);
        }

        public void Clear ()
        {
            _background.Clear();
        }

        public void SetFlip(FlipType flipType)
        {
            _background.SetFlip(flipType);
        }

        #region Animations
        public async UniTask Fade(float value, float time, Ease ease)
        {
            time = MathfExtensions.ClampTime(time);

            await _background.Fade(value, time, ease);
        }

        public async UniTask ChangeColor(Color color, float time, Ease ease)
        {
            time = MathfExtensions.ClampTime(time);

            await _background.ChangeColor(color, time, ease);
        }

        public async UniTask Move(Direction direction, float time, Ease ease)
        {
            time = MathfExtensions.ClampTime(time);

            await _background.Move(direction, time, ease);
        }
        #endregion
    }
}
