using SNEngine.Services;
using TMPro;

namespace SNEngine.DialogSystem.SetFont
{
    internal class SetFontForTextNameCharacterDialogueNode : SetFontDialogWindowNode
    {
        protected override void SetFont(DialogueUIService service, TMP_FontAsset font)
        {
            service.SetFontTextTalkingCharacter(font);
        }
    }
}
