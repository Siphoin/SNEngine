using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SNEngineLib.Interfaces;
using System;
using System.Diagnostics;
using System.Linq;

namespace SNEngineLib.LabelSystem
{
    public abstract class Label :  ILabel
    {
        private LabelDataContainer _container;

        private SpriteBatch _spriteBatch;

        private GraphicsDevice _graphicsDevice;

        private GraphicsDeviceManager _graphics;

        public ILabelDataContainer Container => GetContainer();

        public string Name { get; set; }

        public Label ()
        {
            _container = new LabelDataContainer();
        }

        public void SetGraphicDevice(GraphicsDevice graphicsDevice)
        {

            if (_graphicsDevice != null)
            {
                throw new NullReferenceException("graphic device reference of label has seted");
            }

            _graphicsDevice = graphicsDevice;
        }

        public void SetGraphicDeviceManager(GraphicsDeviceManager graphicsDevice)
        {
            if (_graphics != null)
            {
                throw new NullReferenceException("graphic device reference of label has seted");
            }

            _graphics = graphicsDevice;
        }

        public void SetSpriteBatch(SpriteBatch spriteBatch)
        {
            if (_spriteBatch != null)
            {
                throw new NullReferenceException("sprite batch reference of label has seted");
            }

            _spriteBatch = spriteBatch;
        }

        public void Display()
        {
            _graphicsDevice.Clear(Color.Gray);

            _spriteBatch.Begin();

            if (_container.Background != null)
            {
                IImage background = _container.Background;

                DrawBackground(background);

            }

            IImage[] images = _container.Images.ToArray();

            for (int i = 0; i < images.Length; i++)
            {
                DrawImage(images[i]);
            }

            _spriteBatch.End();
        }

        private void DrawImage (IImage image)
        {
            _spriteBatch.Draw(image.GetTexture(), image.Position, image.Color);
        }

        private void DrawBackground(IImage image)
        {
            _spriteBatch.Draw(image.GetTexture(), new Rectangle((int)image.Position.X, (int)image.Position.Y, _graphics.PreferredBackBufferWidth, _graphics.PreferredBackBufferHeight),
                            new Rectangle(0, 0, image.Width, image.Height),
                           image.Color);
        }

        private ILabelDataContainer GetContainer()
        {
           return _container;
        }

        public virtual void Initialize()
        {
#if DEBUG
            Debug.WriteLine($"label {Name} initialized");
#endif
        }

        public void SetContentManager(ContentManager contentManager)
        {
           if (contentManager == null)
            {
                throw new NullReferenceException("content manager reference is null");
            }

           _container.SetContentManager(contentManager);
           
        }

        public void Dispose()
        {
            _container.Dispose();

#if DEBUG
            Debug.WriteLine("label dispose");
#endif
        }

        public abstract void Update(GameTime gameTime);
    }
}
