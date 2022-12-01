using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SNEngineLib;
using SNEngineLib.LabelSystem;

namespace DemoSNEngine.Labels
{
    internal class FirstLabel : Label
    {
        public FirstLabel ()
        {
            
        }

        public override void Initialize()
        {
            base.Initialize();

            Container.LoadBackground("img/backgrounds/school_background");

           
        }

        public override void Update(GameTime gameTime)
        {
            bool state = Keyboard.GetState().IsKeyDown(Keys.S);

            if (state)
            {
                NovelEngine.Current.JumpToLabel("Label_2");
            }
        }
    }
}
