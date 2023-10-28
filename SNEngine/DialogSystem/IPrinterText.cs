using System;
using TMPro;

namespace SNEngine.DialogSystem
{
    public interface IPrinterText : IResetable
    {
        void SetFontDialog(TMP_FontAsset font);

        void ResetFont();


    }
}
