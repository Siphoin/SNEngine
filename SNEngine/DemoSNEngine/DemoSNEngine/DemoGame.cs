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

        protected override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }
}