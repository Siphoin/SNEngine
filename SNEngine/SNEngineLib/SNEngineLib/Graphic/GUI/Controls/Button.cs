using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SNEngineLib.Interfaces;
using System;

namespace SNEngineLib.Graphic.GUI.Controls
{
    internal class Button : Component, IGraphicObject
    {

        private bool _isHovering;

        private MouseState _previousMouse;

        private MouseState _currentMouse;

        public event EventHandler<EventArgs> OnClick;

        private Image _backgroundButton;

        public int Width { get; set; }

        public int Height { get; set; }

        public int LayerDepth { get; set; } = 0;

        public int Rotation { get; set; } = 0;

        public Text Text { get; private set; }

        public Vector2 Position { get; set; } = new Vector2(0, 0);
        public Color Color { get; set; } = new Color(255, 255, 255, 255);

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle((int)Position.X - (Width / 2), (int)Position.Y - (Height / 2), Width, Height);
            }
        }

        public Vector2 Origin
        {
            get
            {
                float x = Width / 2;
                float y = Height / 2;

                return new Vector2(x, y);
            }
        }

        public Button (Texture2D textureBackground = null, SpriteFont font = null, int width = 300, int height = 100, string text = "New Button")
        {
            if (textureBackground == null)
            {
                textureBackground = (Texture2D)NovelEngine.Current.ContentPipeline.GetAssetEngine("gui/button");
            }

            if (font == null)
            {
               font = (SpriteFont)NovelEngine.Current.ContentPipeline.GetAssetEngine("fonts/button_font");
            }

            Width = width;
            Height = height;

            _backgroundButton = new Image(textureBackground, Position);

            Text = new Text(font);

            Text.TextContainer = text;



        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {

            Color backgroundState = _isHovering ? Color.Gray : Color;
                
            spriteBatch.Draw(_backgroundButton.GetTexture(), Rectangle, backgroundState);

            if (!string.IsNullOrEmpty(Text.TextContainer))
            {
                Vector2 measureString = Text.Font.MeasureString(Text.TextContainer);

                var x = (Rectangle.X + (Rectangle.Width / 2)) - (measureString).X / 2;
                var y = (Rectangle.Y + (Rectangle.Height / 2)) - (measureString).Y / 2;

                spriteBatch.DrawString(Text.Font, Text.TextContainer, new Vector2(x, y), Text.Color);
            }
        }

        public override void Update(GameTime gameTime)
        {
            _previousMouse = _currentMouse;

            _currentMouse = Mouse.GetState();

            var mouseRectangle = new Rectangle(_currentMouse.X, _currentMouse.Y, 1, 1);

            _isHovering = mouseRectangle.Intersects(Rectangle);

            if (_isHovering)
            {

            if (_currentMouse.LeftButton == ButtonState.Released && _previousMouse.LeftButton == ButtonState.Pressed)
            {
                OnClick?.Invoke(this, new EventArgs());
            }

            }


        }

        public  void Dispose()
        {
           Text.Dispose();

           _backgroundButton.Dispose();
        }
    }
}
