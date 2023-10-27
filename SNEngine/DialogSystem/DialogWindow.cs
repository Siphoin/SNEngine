using Cysharp.Threading.Tasks;
using UnityEngine;
using System;
using TMPro;
using SNEngine.Debugging;

namespace SNEngine.DialogSystem
{
    public class DialogWindow : PrinterText, IDialogWindow
    {

        private IDialogNode _dialogNode;

        [SerializeField] private TextMeshProUGUI _textNameCharacter;

        private TMP_FontAsset _defaultFontTextNameCharacter;

        protected override void Awake()
        {
            base.Awake();

            _defaultFontTextNameCharacter = _textNameCharacter.font;
        }

        public void SetData(IDialogNode data)
        {
            _dialogNode = data;
        }

        public void StartOutputDialog()
        {
            if (_dialogNode is null)
            {
                NovelGameDebug.LogError("dialog node is null. Check your Graph");

                return;
            }

            StartOutputDialog(_dialogNode.GetText());
        }

        protected override void End ()
        {
            base.End();

            _dialogNode.MarkIsEnd();

            _dialogNode = null;


        }

        protected override async UniTask Writing(string message)
        {
            _textNameCharacter.text = _dialogNode.Character.GetNameWithColor();

            await base.Writing(message);
        }

        public void SetFontTextTalkingCharacter(TMP_FontAsset font)
        {
            if (font is null)
            {
                NovelGameDebug.LogError($"font for text talking character is null");

                return;
            }

            _textNameCharacter.font = font;
        }

        public override void ResetFont()
        {
            base.ResetFont();

            _textNameCharacter.font = _defaultFontTextNameCharacter;
        }

        public override void ResetState()
        {
            base.ResetState();

            _textNameCharacter.text = string.Empty;
        }
    }
}