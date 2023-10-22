using Cysharp.Threading.Tasks;
using System.Threading;
using UnityEngine;
using System;
using TMPro;
using System.Text;

namespace SNEngine.DialogSystem
{
    public class DialogWindow : MonoBehaviour, IDialogWindow
    {
        private CancellationTokenSource _cancellationTokenSource;

        private IDialogNode _dialogNode;

        [SerializeField, Min(0)] private float _speedWriting = 0.3f;

        [Space]

        [SerializeField] private TextMeshProUGUI _textNameCharacter;

        [SerializeField] private TextMeshProUGUI _textMessage;

        private bool AllTextWrited => _textMessage.text == _dialogNode.GetText();

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

            _textMessage.text = _dialogNode.GetText();
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
                if (Input.GetKeyDown(KeyCode.Space))
                {
                    EndWrite();
                }

                else if (Input.GetMouseButtonDown(0))
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
    }
}