using SNEngine.DialogSystem;
using UnityEngine;

namespace SNEngine.Services
{
    public class MainMenuService : IService, IShowable, IHidden
    {
        private IMainMenu _mainMenu;

        private DialogueService _dialogueService;

        public void Initialize()
        {
            _dialogueService = NovelGame.GetService<DialogueService>();

            var ui = NovelGame.GetService<UIService>();

            var input = Resources.Load<MainMenu>("UI/MainMenu");

            var prefab = Object.Instantiate(input);

            prefab.name = input.name;

            _mainMenu = prefab;

            ui.AddElementToUIContainer(prefab.gameObject);

            _dialogueService.OnEndDialogue += OnEndDialogue;
        }

        private void OnEndDialogue(IDialogue dialogue)
        {
            if (!dialogue.HasNextDialogueOnExit())
            {
                Show();
            }
        }

        public void Show()
        {
            _mainMenu.Show();
        }


        public void Hide()
        {
            _mainMenu.Hide();
        }
    }
}
