using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SNEngineLib.Graphic;
using SNEngineLib.Graphic.GUI;
using SNEngineLib.Interfaces;
using System;

namespace SNEngineLib.Core
{
    public class PanelDialog : Component, IPanelDialog
    {

        private Image _imagePanel;

        private Text _textDialog;

        public PanelDialog (Texture2D texturePanel, SpriteFont fontTextDialog)
        {
            if (fontTextDialog == null)
            {
                throw new ArgumentNullException(nameof(fontTextDialog));
            }

            if (texturePanel == null)
            {
                throw new ArgumentNullException(nameof(texturePanel));
            }

            _imagePanel = new Image(texturePanel, Vector2.Zero);

            _textDialog = new Text(fontTextDialog);
        }


        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_imagePanel.GetTexture(), new Rectangle((int)_imagePanel.Position.X, (int)_imagePanel.Position.Y, Screen.Width, _imagePanel.Height),
            new Rectangle(0, 0, _imagePanel.Width, _imagePanel.Height),
            _imagePanel.Color);
        }

        public override void Update(GameTime gameTime)
        {
            
        }
    }
}
