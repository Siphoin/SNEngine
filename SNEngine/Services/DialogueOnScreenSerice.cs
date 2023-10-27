using SNEngine.DialogOnScreenSystem;
using SNEngine.DialogSystem;
using TMPro;
using UnityEngine;

namespace SNEngine.Services
{
    public class DialogueOnScreenSerice : IService, IPrinterText, IResetable
    {
        private IDialogOnScreenWindow _window;


        public void Initialize()
        {
            var window = Resources.Load<DialogOnScreenWindow>("UI/DalogOnScreenWindow");

            var prefab = Object.Instantiate(window);

            prefab.name = window.name;

            Object.DontDestroyOnLoad(prefab);

            var uiService = NovelGame.GetService<UIService>();

            uiService.AddElementToUIContainer(prefab.gameObject);

            _window = prefab;

            ResetState();
        }

        public void ResetFont()
        {
            _window.ResetFont();
        }

        public void ResetState()
        {
           _window.ResetState();
        }

        public void SetFontDialog(TMP_FontAsset font)
        {
            _window.SetFontDialog(font);
        }

        public void ShowDialog (IDialogOnScreenNode dialog)
        {
            _window.SetData(dialog);

            _window.Show();

            _window.StartOutputDialog();
        }
    }
}
