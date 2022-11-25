using Microsoft.Xna.Framework;
using System;

namespace SNEngineLib.Graphic
{
    public static class Window
    {
        private static GraphicsDeviceManager _graphic;

        private static GameWindow _window;

        public static int Width => _graphic.PreferredBackBufferWidth;

        public static int Height => _graphic.PreferredBackBufferHeight;

        public static Rectangle Bounds => _window.ClientBounds;

        internal static void Initialize(GraphicsDeviceManager graphicsDeviceManager, GameWindow window)
        {
            if (graphicsDeviceManager == null)
            {
                throw new ArgumentNullException("graphic device manager reference is null");
            }

            if (window == null)
            {
                throw new ArgumentNullException(nameof(window));
            }

            _graphic = graphicsDeviceManager;

            _window = window;

        }
    }
}
