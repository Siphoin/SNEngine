using DemoSNEngine.Labels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SNEngineLib;
using SNEngineLib.Core;
using System;
using System.Diagnostics;

namespace DemoSNEngine
{
    public class DemoGame : NovelGame
    {
        private FirstLabel _firstLabel;

        private SecondLabel _secondLabel;

        public DemoGame() : base()
        {
        }

        protected override void Initialize()
        {
            
            Graphics.PreferredBackBufferWidth = 1200;
            Graphics.PreferredBackBufferHeight = 720;
            Graphics.ApplyChanges();

            
            base.Initialize();

        }

        protected override void LoadContent()
        {

            base.LoadContent();

            _firstLabel = new FirstLabel();

            _secondLabel = new SecondLabel();

            Engine.AddLabel(_firstLabel);

            Engine.AddLabel(_secondLabel);

            Character[] characters = new Character[]
{
                new Character("el", Color.Aqua)
};

            AddCharacters(characters);

        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
            {
                Exit();
            }
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}