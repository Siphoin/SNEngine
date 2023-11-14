using UnityEngine;
using System;
using UnityEngine.UI;
using SNEngine.Services;
using UnityEngine.Events;
using TMPro;

namespace SNEngine
{
    public class MainMenu : MonoBehaviour, IMainMenu
    {
        [SerializeField] private Button _buttonNewGamw;
        [SerializeField] private Button _buttonContinue;
        [SerializeField] private Button _buttonSettings;
        [SerializeField] private Button _buttonQuit;

        [SerializeField] private TextMeshProUGUI _textVersion;
        [SerializeField] private TextMeshProUGUI _textAppName;
        [SerializeField] private TextMeshProUGUI _textCompanyName;

        private DialogueService _dialogueService;

        private void Awake()
        {
            if (!_buttonNewGamw)
            {
                throw new NullReferenceException("button new game not seted on main menu script");
            }

            if (!_buttonContinue)
            {
                throw new NullReferenceException("button continue game not seted on main menu script");
            }

            if (!_buttonSettings)
            {
                throw new NullReferenceException("button settings game not seted on main menu script");
            }

            if (!_textVersion)
            {
                throw new NullReferenceException("text version game not seted on main menu script");
            }

            if (!_textAppName)
            {
                throw new NullReferenceException("text app name game not seted on main menu script");
            }

            if (!_textCompanyName)
            {
                throw new NullReferenceException("text company name game not seted on main menu script");
            }

#if UNITY_STANDALONE
            if (!_buttonQuit)
            {
                throw new NullReferenceException("button quit game not seted on main menu script");
            }
#endif

            _dialogueService = NovelGame.GetService<DialogueService>();

            Initialize();
        }

        private void Initialize()
        {
            UnityAction[] actions =
            {
                NewGame,
                Continue,
                OpenSettings,
#if UNITY_STANDALONE
                Exit,
	#endif
            };

            Button[] buttons =
            {
                _buttonNewGamw,
                _buttonContinue,
                _buttonSettings,
#if UNITY_STANDALONE
                _buttonQuit,
	#endif
            };

            for (int i = 0; i < buttons.Length; i++)
            {
                AddListenerToButton(buttons[i], actions[i]);
            }

#if UNITY_ANDROID || UNITY_IOS
            Destroy(_buttonQuit.gameObject);
#endif
            _textVersion.text = Application.version;
            _textAppName.text = Application.productName;
            _textCompanyName.text = Application.companyName;
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        private void AddListenerToButton (Button button, UnityAction action)
        {
            button.onClick.AddListener(action);
        }

        private void NewGame ()
        {
            _dialogueService.JumpToStartDialogue();

            Hide();
        }

        private void Continue ()
        {
            throw new NotImplementedException();
        }

        private void OpenSettings ()
        {
            throw new NotImplementedException();
        }

        private void Exit ()
        {
            Application.Quit();
        }
    }
}