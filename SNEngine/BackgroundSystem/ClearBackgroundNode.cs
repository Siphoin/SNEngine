using SiphoinUnityHelpers.XNodeExtensions;
using SNEngine.Services;

namespace SNEngine.BackgroundSystem
{
    public class ClearBackgroundNode : BaseNodeInteraction
    {
        public override void Execute()
        {
            var backgroundService = NovelGame.GetService<BackgroundService>();

            backgroundService.Clear();
        }
    }
}
