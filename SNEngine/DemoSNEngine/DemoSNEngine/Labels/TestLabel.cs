using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SNEngineLib.LabelSystem;

namespace DemoSNEngine.Labels
{
    internal class TestLabel : Label
    {
        public TestLabel ()
        {

        }

        public override void Initialize()
        {
            base.Initialize();
            Container.LoadBackground("img/school_background");

            Container.LoadAsset<Texture2D>("img/apple", true);

           
        }

        public override void Update(GameTime gameTime)
        {
            
        }
    }
}
