using DemoSNEngine.Labels;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using SNEngineLib;
using System;
using System.Diagnostics;

namespace DemoSNEngine
{
    public class DemoGame : NovelGame
    {
        private TestLabel testLabel;

        private LabelTwo labelTwo;

        public DemoGame() : base()
        {
        }

        protected override void Initialize()
        {
            base.Initialize();

        }

        protected override void LoadContent()
        {
            base.LoadContent();

            testLabel = new TestLabel();

            labelTwo = new LabelTwo();

            Engine.AddLabel(testLabel);

            Engine.AddLabel(labelTwo);

        }

        private void JumptoLabelTwo()
        {
            Engine.JumpToLabel(labelTwo);
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

                    case Keys.D:
                        {
                            Engine.JumpToLabel("Label_1");
                            break;
                        }
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}