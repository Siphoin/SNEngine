using SNEngine.Services;
using TMPro;

namespace SNEngine.DialogSystem.SetFont
{
    [NodeWidth(270)]
    public abstract class SetFontDialogWindowNode : SetFontNode
    {

        protected abstract void SetFont(DialogueUIService service, TMP_FontAsset font);

        protected override void SetFont(TMP_FontAsset font)
        {
            var serviceDialogs = NovelGame.GetService<DialogueUIService>();

            SetFont(serviceDialogs, font);
        }
    }
}
