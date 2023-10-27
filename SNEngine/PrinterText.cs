using Cysharp.Threading.Tasks;
using SNEngine.Debugging;
using SNEngine.DialogSystem;
using SNEngine.InputSystem;
using SNEngine.Services;
using System;
using System.Text;
using System.Threading;
using TMPro;
using UnityEngine;

namespace SNEngine
{
    public abstract class PrinterText : MonoBehaviour, IPrinterText, IShowable, IHidden
    {
        private CancellationTokenSource _cancellationTokenSource;

        private string _currentText;

        [SerializeField, Min(0)] private float _speedWriting = 0.3f;

        [Space]

        [SerializeField] private TextMeshProUGUI _textMessage;

        private TMP_FontAsset _defaultFontTextDialog;

        private IInputSystem _inputSystem;

        protected bool AllTextWrited => _textMessage.text == _currentText;

        public string CurrentText => _currentText;

        protected virtual void Awake()
        {
            _defaultFontTextDialog = _textMessage.font;

            _inputSystem = NovelGame.GetService<InputService>();
        }

        public void Hide()
        {
            gameObject.SetActive(false);

        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

#if UNITY_STANDALONE
        protected virtual void OnPress(KeyCode key)
        {
            if (_cancellationTokenSource != null)
            {
                if (key == KeyCode.Space || key == KeyCode.Mouse0)
                {
                    EndWrite();
                }
            }
        }
#endif

        protected virtual void StartOutputDialog(string message)
        {
#if UNITY_STANDALONE
            _inputSystem.AddListener(OnPress, StandaloneInputEventType.KeyDown);
#endif

#if UNITY_ANDROID || UNITY_IOS
            _inputSystem.AddListener(OnTapScreen, MobileInputEventType.TouchBegan);
#endif

            Writing(message).Forget();


        }
#if UNITY_ANDROID || UNITY_IOS
        protected virtual void OnTapScreen(Touch touch)
        {
            if (_cancellationTokenSource != null)
            {
                EndWrite();
            }
        }
#endif

        protected virtual void EndWrite()
        {
            if (AllTextWrited)
            {
                End();

                return;
            }

            _cancellationTokenSource?.Cancel();

            _textMessage.text = _currentText;

        }

        protected virtual void End()
        {

            _cancellationTokenSource = null;

#if UNITY_STANDALONE
            _inputSystem.RemoveListener(OnPress, StandaloneInputEventType.KeyDown);
#endif

#if UNITY_ANDROID || UNITY_IOS
            _inputSystem.RemoveListener(OnTapScreen, MobileInputEventType.TouchBegan);
#endif

            Hide();


        }

        protected virtual async UniTask Writing(string message)
        {
            _cancellationTokenSource = new CancellationTokenSource();

            var token = _cancellationTokenSource.Token;

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

        public virtual void ResetFont()
        {
            _textMessage.font = _defaultFontTextDialog;
        }

        public virtual void ResetState()
        {
            _cancellationTokenSource?.Cancel();

            _cancellationTokenSource = null;

            _textMessage.text = string.Empty;

            _currentText = string.Empty;

            ResetFont();

            Hide();
        }
    }
}