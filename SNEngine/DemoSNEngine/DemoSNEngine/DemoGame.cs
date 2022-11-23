using DemoSNEngine.Labels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SNEngineLib;
using System;
using System.Diagnostics;

namespace DemoSNEngine
{
    public class DemoGame : Game
    {
        private GraphicsDeviceManager _graphics;

        private SpriteBatch _spriteBatch;

        private NovelEngine _novelEngine;

        private TestLabel testLabel;

        private LabelTwo labelTwo;

        public DemoGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();

        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            _novelEngine = new NovelEngine(_spriteBatch, GraphicsDevice, _graphics, Content);

            

            testLabel = new TestLabel();

            labelTwo = new LabelTwo();


            _novelEngine.AddLabel(testLabel);

            _novelEngine.AddLabel(labelTwo);

        }

        private void JumptoLabelTwo()
        {
                _novelEngine.JumpToLabel(labelTwo);

            Debug.WriteLine(45);
            

        }

        protected override void Update(GameTime gameTime)
        {
            var keys = Keyboard.GetState().GetPressedKeys();
            if (keys.Length > 0)
            {
                var k = keys[0];
                switch (k)
                {
                    case Keys.Escape:
                        {
                            Exit();
                            break;
                        }

                    case Keys.S:
                        {
                            JumptoLabelTwo();
                            break;
                        }
                }
            }
            _novelEngine.Update(gameTime);



            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            _novelEngine.Draw(gameTime, _spriteBatch);

            base.Draw(gameTime);
        }
    }
}