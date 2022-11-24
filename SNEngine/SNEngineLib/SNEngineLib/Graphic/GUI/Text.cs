using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SNEngineLib.Interfaces;

namespace SNEngineLib.Graphic.GUI
{
    public class Text : Component, IGraphicObject
    {



        public int Width => throw new System.NotImplementedException();

        public int Height => throw new System.NotImplementedException();

        public string TextContainer { get; set; }

        public Vector2 Position { get; set; } = new Vector2(0, 0);
        public Color Color { get; set; } = Color.White;

        public SpriteFont Font { get; set; }

        public Text (SpriteFont font)
        {
            if (font == null)
            {
                throw new System.ArgumentNullException((nameof(font)));
            }

            Font = font;

            TextContainer = "New Text";
        }


        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
           spriteBatch.DrawString(Font, TextContainer, Position, Color);
        }

        public override void Update(GameTime gameTime)
        {
            return;
        }

        public void Dispose()
        {
            Font = null;

            TextContainer = null;
        }
    }
}
