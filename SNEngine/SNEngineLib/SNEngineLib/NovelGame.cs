using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SNEngineLib.Interfaces;

namespace SNEngineLib
{
    public abstract class NovelGame : Game
    {
        private NovelEngine _novelEngine;

        private GraphicsDeviceManager _graphics;

        private SpriteBatch _spriteBatch;

        protected GraphicsDeviceManager Graphics { get => _graphics; }

        protected SpriteBatch SpriteBatch { get => _spriteBatch; }

        protected INovelEngine Engine { get => _novelEngine; }

        public NovelGame ()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _novelEngine = new NovelEngine(_spriteBatch, GraphicsDevice, _graphics, Content);

            base.LoadContent();
        }

        protected override void Draw(GameTime gameTime)
        {
            _novelEngine.Draw(gameTime, _spriteBatch);

            base.Draw(gameTime);
        }

        protected override void Update(GameTime gameTime)
        {
            _novelEngine.Update(gameTime);

            base.Update(gameTime);
        }


    }
}
