using SNEngine.Animations;
using SNEngine.Services;

namespace SNEngine.BackgroundSystem
{
    public class SetFlipBackgroundNode : SetFlipNode
    {
        protected override void SetFlip(FlipType flipType)
        {
            var backgroundService = NovelGame.GetService<BackgroundService>();

            backgroundService.SetFlip(flipType);
        }
    }
}
