using Microsoft.Xna.Framework;
using System;

namespace SNEngineLib.Interfaces
{
    public interface IGraphicObject : IDisposable
    {
        public int Width { get; }

        public int Height { get; }

        public Vector2 Origin { get; }

        public Vector2 Position { get; set; }

        public Color Color { get; set; }
    }
}
