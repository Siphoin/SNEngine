using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SNEngineLib;
using SNEngineLib.InputSystem;
using SNEngineLib.LabelSystem;

namespace DemoSNEngine.Labels
{
    public class SecondLabel : Label
    {

        public override void Initialize()
        {
            base.Initialize();

            Container.LoadBackground("img/backgrounds/school_background_2");
        }

        public override void Update(GameTime gameTime)
        {
            if (Input.GetKeyDown(Keys.S))
            {
                NovelEngine.Current.JumpToLabel("Label_1");
            }
        }

    }
}
