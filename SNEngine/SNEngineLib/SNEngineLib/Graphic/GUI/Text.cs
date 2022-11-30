using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SNEngineLib.Interfaces;
using System;

namespace SNEngineLib.Graphic.GUI
{
    public class Text : Component, IGraphicObject
    {



        public int Width => throw new NotImplementedException();

        public int Height => throw new NotImplementedException();

        public string TextContainer { get; set; }

        public Vector2 Position { get; set; } = new Vector2(0, 0);
        public Color Color { get; set; } = Color.Black;

        public SpriteFont Font { get; set; }

        public Vector2 Origin
        {
            get
            {
                float x = Width / 2;
                float y = Height / 2;

                return new Vector2(x, y);
            }
        }


        public Text (SpriteFont font = null)
        {
            if (font == null)
            {
                font = (SpriteFont)NovelEngine.Current.ContentPipeline.GetAssetEngine("fonts/default_font");
            }

            IsUpdatable = false;

            Font = font;

            TextContainer = "New Text";
        }


        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
           spriteBatch.DrawString(Font, TextContainer, Position, Color);
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public  void Dispose()
        {
            Font = null;

            TextContainer = null;
        }
    }
}
