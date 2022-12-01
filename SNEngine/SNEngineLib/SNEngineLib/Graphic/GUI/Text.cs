using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SNEngineLib.Interfaces;
using System;

namespace SNEngineLib.Graphic.GUI
{
    public class Text : Component, IGraphicObject
    {



        public int Width { get; set; } = 100;

        public int Height { get; set; } = 100;

        public int LayerDepth { get; set; } = 0;
        public int Rotation { get; set; } = 0;

        public string TextContainer { get; set; }

        public Vector2 Position { get; set; } = new Vector2(0, 0);
        public Color Color { get; set; } = Color.White;

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
                font = NovelEngine.Current.ContentPipeline.GetAssetEngine<SpriteFont>("fonts/default_font");
            }

            IsUpdatable = false;

            Font = font;

            TextContainer = "New Text";

            
        }


        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
           spriteBatch.DrawString(Font, Normalize(), Position, Color);
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

        private string Normalize()
        {
            string line = string.Empty;
            string returnString = string.Empty;
            string[] wordArray = TextContainer.Split(' ');



            foreach (string word in wordArray)
            {
                if (Font.MeasureString(line + word).Length() > Width)
                {
                    returnString = returnString + line + Environment.NewLine;
                    line = string.Empty;
                    
                }
                line = line + word + ' ';
            }



            return returnString + line;
        }
    }
}
