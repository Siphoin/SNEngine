using System.Collections.Generic;

namespace SNEngine.SelectVariantsSystem
{
    public interface IShowerVariants
    {
        void ShowVariants(IEnumerable<string> variants, bool hideCharacters = true, bool hideDialogWindow = true, bool returnCharactersVisible = true, AnimationButtonsType animationType = AnimationButtonsType.None);
    }
}
