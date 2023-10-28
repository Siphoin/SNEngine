using System.Collections;
using TMPro;
using UnityEngine;
using System;
namespace SNEngine.Animations.TextEffects
{
    [RequireComponent(typeof(TextMeshProUGUI))]
    public abstract class TextEffect : MonoBehaviour
    {
        private TextMeshProUGUI _textMesh;

        [SerializeField] private PrinterText _printerText;

        protected float SpeedWritingText => _printerText.SpeedWriting;

        protected bool AllTextWrited => _printerText.AllTextWrited;

        private void Awake()
        {
            if (!_printerText)
            {
                throw new NullReferenceException($"printer text not seted. GameObject {name}");
            }

            if (!TryGetComponent(out _textMesh))
            {
                throw new NullReferenceException("text mesh component is null");
            }
        }

        private void OnEnable()
        {
            _printerText.OnWriteSymbol += OnWriteSymbol;
        }

        private void OnDisable()
        {
            _printerText.OnWriteSymbol -= OnWriteSymbol;
        }

        private void OnWriteSymbol()
        {
            TextUpdate(_textMesh);
        }

        protected abstract void TextUpdate(TextMeshProUGUI textMesh);
    }
}