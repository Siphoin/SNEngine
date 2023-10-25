using SNEngine.Polling;
using UnityEngine;
using System;
using System.Collections.Generic;
using SNEngine.Debugging;
using UnityEngine.UI;

namespace SNEngine.SelectVariantsSystem
{
    [RequireComponent(typeof(GridLayoutGroup))]
    public class VariantsSelectWindow : MonoBehaviour, IVariantsSelectWindow
    {
        private PoolMono<VariantButton> _pool;

        [SerializeField] private VariantButton _buttonPrefab;

        [Space]

        [SerializeField, Min(2)] private int _buttonsCreatedOnStart = 5;

        public event Action<int> OnSelect;
        

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void SetData(IEnumerable<string> data)
        {
            foreach (var item in data)
            {
                var button = _pool.GetFreeElement();

                button.OnSelect += OnSelectVariant;

                button.SetData(item);
            }
        }

        private void OnSelectVariant(int index)
        {
            NovelGameDebug.Log($"user selected button variant by index {index}");

            var buttons = _pool.Objects;

            foreach (var button in buttons)
            {
                button.OnSelect -= OnSelectVariant;

                button.Hide();
            }

            OnSelect?.Invoke(index);

            Hide();
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }
        private void Awake()
        {
            _pool = new PoolMono<VariantButton>(_buttonPrefab, transform, _buttonsCreatedOnStart, true);
        }

        public void ShowVariants(IEnumerable<string> variants)
        {
            Show();

            SetData(variants);
        }
    }
}