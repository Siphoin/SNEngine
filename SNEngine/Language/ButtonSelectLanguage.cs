using System;
using UnityEngine;
using UnityEngine.UI;

namespace SNEngine.Language
{
    [RequireComponent(typeof(Button))]
    public class ButtonSelectLanguage : MonoBehaviour
    {
        private Button _button;
        private void Awake()
        {
            if (!TryGetComponent(out _button))
            {
                throw new NullReferenceException("button select language must have component Button");
            }

            _button.onClick.AddListener(OpenWindow);
        }
        public void OpenWindow()
        {
            throw new NotImplementedException();
        }
    }
}