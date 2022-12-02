using DemoSNEngine.Labels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SNEngineLib;
using SNEngineLib.Core;
using SNEngineLib.InputSystem;
using SNEngineLib.LabelSystem;

namespace DemoSNEngine
{
    public class DemoGame : NovelGame
    {
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

            Label[] labels = new Label[]
            {
                new FirstLabel(),
                new SecondLabel(),
            };

            Character[] characters = new Character[]
            {
                new Character("el", Color.Aqua)
            };


            AddLabels(labels);

            AddCharacters(characters);

        }

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (Input.GetKeyDown(Keys.Escape))
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