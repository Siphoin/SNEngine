using SNEngine.SelectVariantsSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SNEngine.Services
{
    public class SelectVariantsService : IService, IShowerVariants, ISelectableVariant
    {
        private IVariantsSelectWindow _window;

        public event Action<int> OnSelect;

        public void Initialize()
        {
            var window = Resources.Load<VariantsSelectWindow>("UI/WindowSelecVariants");

            var prefab = Object.Instantiate(window);

            prefab.name = window.name;

            Object.DontDestroyOnLoad(prefab);

            var uiService = NovelGame.GetService<UIService>();

            uiService.AddElementToUIContainer(prefab.gameObject);

            _window = prefab;

            _window.Hide();
        }

        public void ShowVariants (IEnumerable<string> variants)
        {
            _window.OnSelect += OnSelectVariant;

            _window.ShowVariants(variants);
        }

        private void OnSelectVariant(int index)
        {
            _window.OnSelect -= OnSelectVariant;

            OnSelect?.Invoke(index);
        }
    }
}
