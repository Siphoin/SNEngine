using Microsoft.Xna.Framework;

namespace SNEngineLib.Interfaces
{
    public interface IGraphicObject
    {
        public int Width { get; }

        public int Height { get; }
        public Vector2 Position { get; set; }

        public Color Color { get; set; }
    }
}
