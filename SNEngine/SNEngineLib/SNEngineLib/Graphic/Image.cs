using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SNEngineLib.Interfaces;

namespace SNEngineLib.Graphic
{
    public class Image : IImage
    {
        private Texture2D _texture;

        public Vector2 Position { get; set; } = new Vector2(0, 0);
        public Color Color { get; set; } = Color.White;

        public int Width => _texture.Width;

        public int Height => _texture.Height;

        public Image ()
        {

        }

        public Image (Texture2D texture, Vector2 position)
        {
            _texture = texture;
            Position = position;
        }

        public Image (Texture2D texture)
        {
            _texture = texture;
        }

        public Texture2D GetTexture()
            => _texture;
    }
}
