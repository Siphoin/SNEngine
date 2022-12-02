using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SNEngineLib;
using SNEngineLib.InputSystem;
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
            if (Input.GetKeyDown(Keys.S))
            {
                NovelEngine.Current.JumpToLabel("Label_2");
            }
        }
    }
}
