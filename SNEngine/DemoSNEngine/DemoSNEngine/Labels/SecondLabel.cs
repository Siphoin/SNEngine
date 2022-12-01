using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using SNEngineLib;
using SNEngineLib.LabelSystem;

namespace DemoSNEngine.Labels
{
    public class SecondLabel : Label
    {

        public override void Initialize()
        {
            base.Initialize();

            Container.LoadBackground("img/school_background_2");
        }

        public override void Update(GameTime gameTime)
        {
            bool state = Keyboard.GetState().IsKeyDown(Keys.D);

            if (state)
            {
                NovelEngine.Current.JumpToLabel("Label_1");
            }
        }

    }
}
