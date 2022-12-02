using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SNEngineLib.Core;
using SNEngineLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

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

            _novelEngine = new NovelEngine(_spriteBatch, GraphicsDevice, _graphics, Content, Window, this);

            base.LoadContent();
        }

        

        protected override void Draw(GameTime gameTime)
        {
            if (!IsActive)
            {
                return;
            }

            _novelEngine.Draw(gameTime, _spriteBatch);

            base.Draw(gameTime);
        }

        protected override void Update(GameTime gameTime)
        {
            if (!IsActive)
            {
                return;
            }

            _novelEngine.Update(gameTime);

            base.Update(gameTime);
        }

        protected void AddLabels (ICollection<ILabel> labels)
        {
            if (labels == null)
            {
                throw new ArgumentNullException("collection of labels as empty");
            }

            if (labels.Count == 0)
            {
#if DEBUG
                Debug.WriteLine("collection of labels not contains items");
#endif
                return;
            }

            ILabel[] collection = labels.ToArray();

            if (collection.Count(x => x == null) > 0)
            {
                throw new Exception("collection of labels contains Null References");
            }

            foreach (var item in collection)
            {
                _novelEngine.AddLabel(item);
            }


        }

        protected void AddCharacters (ICollection<ICharacter> characterCollection)
        {
            if (characterCollection == null)
            {
                throw new ArgumentNullException("collection of characters as empty");
            }

            if (characterCollection.Count == 0)
            {
#if DEBUG
                Debug.WriteLine("collection of characters not contains items");
#endif
                return;
            }

            ICharacter[] characters = characterCollection.ToArray();

            if (characters.Count(x => x == null) > 0)
            {
                throw new Exception("collection of characters contains Null References");
            }

            foreach (var character in characters)
            {
                _novelEngine.AddCharacter(character);
            }
        }


    }
}
