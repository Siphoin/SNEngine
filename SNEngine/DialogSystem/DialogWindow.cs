using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;
using System;
using TMPro;
using System.Text;
using SNEngine.Debugging;

namespace SNEngine.DialogSystem
{
    public class DialogWindow : MonoBehaviour, IDialogWindow
    {
        private CancellationTokenSource _cancellationTokenSource;

        private IDialogNode _dialogNode;

        private string _currentText;

        [SerializeField, Min(0)] private float _speedWriting = 0.3f;

        [Space]

        [SerializeField] private TextMeshProUGUI _textNameCharacter;

        [SerializeField] private TextMeshProUGUI _textMessage;

        private TMP_FontAsset _defaultFontTextNameCharacter;

        private TMP_FontAsset _defaultFontTextDialog;

        private bool AllTextWrited => _textMessage.text == _currentText;

        private void Awake()
        {
            _defaultFontTextDialog = _textMessage.font;

            _defaultFontTextNameCharacter = _textNameCharacter.font;
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void SetData(IDialogNode data)
        {
            if (_cancellationTokenSource != null)
            {
                throw new InvalidOperationException("dialog window not end last seted dialog");
            }

            _dialogNode = data;
        }

        public void StartOutputDialog ()
        {
            if (_dialogNode is null)
            {
                throw new ArgumentNullException("dialog node is null");
            }

            Writing().Forget();


        }

        private void EndWrite ()
        {

            if (AllTextWrited)
            {
                End();

                return;
            }

            _cancellationTokenSource?.Cancel();

            _textMessage.text = _currentText;

        }

        private void End ()
        {
            _dialogNode.MarkIsEnd();

            _dialogNode = null;

            _cancellationTokenSource = null;
        }

        private void Update()
        {
            if ( _cancellationTokenSource != null)
            {
                if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0) || Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
                {
                    EndWrite();
                }
            }


        }

        private async UniTask Writing()
        {
            _cancellationTokenSource = new CancellationTokenSource();

            _textNameCharacter.text = _dialogNode.Character.GetNameWithColor();

            var token = _cancellationTokenSource.Token;

            var message = _dialogNode.GetText();

            _currentText = message;

            var stringBuilder = new StringBuilder();

            for (int i = 0; i < message.Length; i++)
            {
                if (token.IsCancellationRequested)
                {
                    break;
                }

                stringBuilder.Append(message[i]);

                _textMessage.text = stringBuilder.ToString();

                await UniTask.Delay(TimeSpan.FromSeconds(_speedWriting), cancellationToken: token);
            }
        }

        public void SetFontDialog(TMP_FontAsset font)
        {
            if (font is null)
            {
                NovelGameDebug.LogError($"font for text dialog is null");

                return;
            }

            _textMessage.font = font;
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

        public void ResetFont()
        {
            _textMessage.font = _defaultFontTextDialog;

            _textNameCharacter.font = _defaultFontTextNameCharacter;
        }

        public void ResetState()
        {
            _cancellationTokenSource?.Cancel();

            _cancellationTokenSource = null;

            _textMessage.text = string.Empty;

            _textNameCharacter.text += string.Empty;

            _currentText = string.Empty;

            ResetFont();

            Hide();
        }
    }
}