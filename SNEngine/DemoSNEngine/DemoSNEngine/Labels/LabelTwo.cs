using SNEngineLib.LabelSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoSNEngine.Labels
{
    public class LabelTwo : Label
    {
        public override void Initialize()
        {
            base.Initialize();

            Container.LoadBackground("img/school_background_2");
        }
    }
}
