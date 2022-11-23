using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace SNEngineLib
{
    public static class Screen
    {
        private static GraphicsDeviceManager _graphic;

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
            _graphic.PreferredBackBufferWidth = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width;
            _graphic.PreferredBackBufferHeight = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height;

            FullScreen = fullScreen;

            _graphic.IsFullScreen = FullScreen;

            _graphic.ApplyChanges();
        }


    }
}
