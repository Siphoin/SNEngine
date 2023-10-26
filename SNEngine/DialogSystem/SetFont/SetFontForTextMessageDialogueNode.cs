using SNEngine.Services;
using TMPro;

namespace SNEngine.DialogSystem.SetFont
{
    public class SetFontForTextMessageDialogueNode : SetFontDialogWindowNode
    {
        protected override void SetFont(DialogueUIService service, TMP_FontAsset font)
        {
             service.SetFontDialog(font);
        }
    }
}
