using SiphoinUnityHelpers.XNodeExtensions;
using SNEngine.Services;

namespace SNEngine.DialogSystem
{
    public class HideDiaklogWindowNode : BaseNodeInteraction
    {
        public override void Execute()
        {
            var serviceDialogs = NovelGame.GetService<DialogueUIService>();

            serviceDialogs.HideDialog();
        }
    }
}
