using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace SNEngineLib
{
    public static class Screen
    {

        public static event Action<Vector2> OnFullScreen;

        private static GraphicsDeviceManager _graphic;

        public static int Width => GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;

        public static int Height => GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

        public static bool FullScreen { get; private set; } = false;

        internal static void Initialize(GraphicsDeviceManager graphicsDeviceManager)
        {
            if (graphicsDeviceManager == null)
            {
                throw new NullReferenceException("graphic device manager reference is null");
            }
            _graphic = graphicsDeviceManager;

            FullScreen = _graphic.IsFullScreen;
        }

        public static void SetFullScreen(bool fullScreen)
        {
            if (fullScreen == FullScreen)
            {
                return;
            }


            _graphic.PreferredBackBufferWidth = Width;
            _graphic.PreferredBackBufferHeight = Height;

            FullScreen = fullScreen;

            _graphic.IsFullScreen = FullScreen;

            _graphic.ApplyChanges();

            Vector2 screenSize = new Vector2(_graphic.PreferredBackBufferWidth, _graphic.PreferredBackBufferHeight);

            OnFullScreen?.Invoke(screenSize);
        }


    }
}
