using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SNEngineLib.Graphic;
using SNEngineLib.Graphic.GUI;
using SNEngineLib.Interfaces;
using System;

namespace SNEngineLib.Core
{
    public class PanelDialog : Component, IPanelDialog, IDisposable
    {

        private bool _isShow;

        private Image _imagePanel;

        private Text _textDialog;

        public bool IsShow => _isShow;

        public PanelDialog ()
        {
            _isShow = true;

            IsUpdatable = false;
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
            throw new NotImplementedException();
        }

        internal void Initialize()
        {
            IContentPipeline content = NovelEngine.Current.ContentPipeline;
            Screen.OnFullScreen += Resize;

            SpriteFont font = (SpriteFont)content.GetAssetEngine("fonts/window_dialog_font");

            Texture2D texturePanel = (Texture2D)content.GetAssetEngine("gui/window_dialog");

            float y = Screen.FullScreen ? Screen.Width : Window.Width;

            _imagePanel = new Image(texturePanel, new Vector2(0, y / 2));

            _textDialog = new Text(font);

            _imagePanel.Color = new Color(255, 255, 255, 125);


        }

        private void Resize(Vector2 obj)
        {
            float y = Window.Width;

            _imagePanel.Position = new Vector2(0, y / 2);
        }

        public void SetShowState(bool state)
        {
            _isShow = state;
        }

        public void Dispose()
        {
            Screen.OnFullScreen -= Resize;

            _imagePanel.Dispose();
        }
    }
}
