using SiphoinUnityHelpers.XNodeExtensions;
using TMPro;
using UnityEngine;

namespace SNEngine.DialogSystem.SetFont
{
    public abstract class SetFontNode : BaseNodeInteraction
    {
        [SerializeField] private TMP_FontAsset _font;

        public override void Execute()
        {
            SetFont(_font);
        }

        protected abstract void SetFont(TMP_FontAsset font);
    }
}
