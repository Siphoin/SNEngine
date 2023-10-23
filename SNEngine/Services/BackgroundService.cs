using SNEngine.BackgroundSystem;
using UnityEngine;

namespace SNEngine.Services
{
    
    public class BackgroundService : IService, IResetable
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
    }
}
