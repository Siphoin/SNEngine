using SNEngine.DialogSystem;
using UnityEngine;

namespace SNEngine.Services
{
    public class DialogueService : IService, IResetable
    {
        private IDialogWindow _dialogWindow;
        public void Initialize()
        {
            var dialogWindow = Resources.Load<DialogWindow>("UI/dialogue");

            var dialogWindowPrefab = Object.Instantiate(dialogWindow);

            dialogWindowPrefab.name = dialogWindow.name;

            Object.DontDestroyOnLoad(dialogWindowPrefab);

            _dialogWindow = dialogWindowPrefab;

            var uiService = NovelGame.GetService<UIService>();

            uiService.AddUIElementToUIContainer(dialogWindowPrefab.gameObject);

            HideDialog();

        }

        public void ShowDialog (IDialogNode dialogNode)
        {
            _dialogWindow.SetData(dialogNode);

            _dialogWindow.Show();

            _dialogWindow.StartOutputDialog();
        }

        public void HideDialog ()
        {
            _dialogWindow.Hide();
        }

        public void ResetState()
        {
           _dialogWindow.ResetState();
        }
    }
}
