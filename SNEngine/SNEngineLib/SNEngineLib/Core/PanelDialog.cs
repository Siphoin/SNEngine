using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SNEngineLib.Graphic;
using SNEngineLib.Graphic.GUI;
using SNEngineLib.Interfaces;
using System;

namespace SNEngineLib.Core
{
    public class PanelDialog : Component, IPanelDialog
    {

        private bool _isShow;

        private Image _imagePanel;

        private Text _textDialog;

        public bool IsShow => _isShow;

        public PanelDialog ()
        {

            _isShow = true;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (!_isShow)
            {
                return;
            }
            spriteBatch.Draw(_imagePanel.GetTexture(), new Rectangle((int)_imagePanel.Position.X, (int)_imagePanel.Position.Y, Screen.Width, _imagePanel.Height),
            new Rectangle(0, 0, _imagePanel.Width, _imagePanel.Height),
            _imagePanel.Color);
        }

        public override void Update(GameTime gameTime)
        {
            
        }

        internal void Initialize(ContentManager contentManager)
        {
            if (contentManager == null)
            {
                throw new ArgumentNullException(nameof(contentManager));
            }

            SpriteFont font = contentManager.Load<SpriteFont>("engine_assets/fonts/arial");

            Texture2D texturePanel = contentManager.Load<Texture2D>("engine_assets/gui/window_dialog");

            float y = Screen.FullScreen ? Screen.Width : Window.Width;

            _imagePanel = new Image(texturePanel, new Vector2(0, y / 2));

            _textDialog = new Text(font);

            _imagePanel.Color = new Color(255, 255, 255, 125);


        }

        public void SetShowState(bool state)
        {
            _isShow = state;
        }
    }
}
