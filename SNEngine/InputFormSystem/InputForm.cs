using TMPro;
using UnityEngine;
using System;
using UnityEngine.Events;
using UnityEngine.UI;
namespace SNEngine.InputFormSystem
{
    public class InputForm : MonoBehaviour, IInputForm
    {
        [SerializeField] private InputFormType _type;

        [SerializeField] private TMP_InputField _input;

        [SerializeField] private TextMeshProUGUI _label;

        [SerializeField] private Button _sumbitButton;

        public event UnityAction<string> OnSubmit;

        public bool IsTrimming { get; set; }

        public string Label { get => _label.text; set => _label.text = value; }

        public InputFormType Type => _type;

        private void Awake()
        {
            if (!_input)
            {
                throw new NullReferenceException("input is null on input form");
            }

            if (!_label)
            {
                throw new NullReferenceException("label is null on input form");
            }

            if (!_sumbitButton)
            {
                throw new NullReferenceException("submit button is null on input form");
            }

            _sumbitButton.onClick.AddListener(Submit);
        }

        private void Submit ()
        {
            if (IsTrimming)
            {
                _input.text = _input.text.Trim();
            }

            OnSubmit?.Invoke(_input.text);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void ResetState()
        {
            Label = string.Empty;

            _input.text = string.Empty;

            Hide();
        }
    }
}