using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
namespace SNEngine.SelectVariantsSystem
{
    [RequireComponent(typeof(Button))]
    public class VariantButton : MonoBehaviour, ISeterData<string>
    {
        [SerializeField] private TextMeshProUGUI _textButton;

        private Button _button;

        public event Action<int> OnSelect;

        private void Awake()
        {
            if (!_textButton)
            {
                throw new NullReferenceException("text button is null");
            }

            if (!TryGetComponent(out _button))
            {
                throw new NullReferenceException("button component is null");
            }

            _button.onClick.AddListener(Select);
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void SetData(string data)
        {
            _textButton.text = data;
        }

        private void Select()
        {
            int index = transform.GetSiblingIndex();

            OnSelect?.Invoke(index);
        }
    }
}