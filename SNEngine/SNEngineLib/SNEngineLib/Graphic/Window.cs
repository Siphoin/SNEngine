using Microsoft.Xna.Framework;
using System;

namespace SNEngineLib.Graphic
{
    public static class Window
    {
        private static GraphicsDeviceManager _graphic;

        public static int Width => _graphic.PreferredBackBufferWidth;

        public static int Height => _graphic.PreferredBackBufferHeight;

        internal static void Initialize(GraphicsDeviceManager graphicsDeviceManager)
        {
            if (graphicsDeviceManager == null)
            {
                throw new NullReferenceException("graphic device manager reference is null");
            }
            _graphic = graphicsDeviceManager;

        }
    }
}
