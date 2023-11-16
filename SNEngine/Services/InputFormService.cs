using SNEngine.InputFormSystem;
using UnityEngine;
using SNEngine.Debugging;
using System.Linq;
using UnityEngine.Events;
namespace SNEngine.Services
{
    public class InputFormService : IService, IHidden, ISubmitter, IResetable
    {
        public event UnityAction<string> OnSubmit;

        private IInputForm[] _forms;
        private IInputForm _activeForm;

        public void Initialize()
        {
            var forms = Resources.LoadAll<InputForm>("UI");

            var uiService = NovelGame.GetService<UIService>();

            _forms = new IInputForm[forms.Length];

            for ( int i = 0; i < forms.Length; i++ )
            {
                var form = Object.Instantiate(forms[i]);

                _forms[i] = form;

                uiService.AddElementToUIContainer(form.gameObject);
            }


            NovelGameDebug.Log($"loaded {_forms.Length} {nameof(InputForm)}s");

            ResetState();


        }

        public void Show (InputFormType type, string label, bool isTriming)
        {
            if (_activeForm != null)
            {
                NovelGameDebug.LogError("multiple calls show input form detected");

                return;
            }

            var form = _forms.SingleOrDefault(x => x.Type == type);

            if (form is null)
            {
                NovelGameDebug.LogError($"input form with type {type} not found on service {GetType().Name}");

                return;
            }

            form.Label = label;
            form.IsTrimming = isTriming;

            form.Show();

            _activeForm = form;

            _activeForm.OnSubmit += OnSumbitText;
        }

        private void OnSumbitText(string text)
        {
            _activeForm.OnSubmit -= OnSumbitText;

            OnSubmit?.Invoke(text);
        }

        public void Hide ()
        {
            _activeForm?.Hide();
            _activeForm = null;
        }

        public void ResetState()
        {
            for (int i = 0; i < _forms.Length; i++)
            {
                _forms[i].ResetState();
            }
        }
    }
}
