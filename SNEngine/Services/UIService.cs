using SNEngine.UI;
using UnityEngine;
using System;
using Object = UnityEngine.Object;

namespace SNEngine.Services
{
    public class UIService : IService
    {
        private IUIContainer _container;
        public void Initialize()
        {
            var container = Resources.Load<UIContainer>("UI/UIContainer");

            var prefab = Object.Instantiate(container);

            prefab.name = container.name;

            Object.DontDestroyOnLoad(prefab);

            _container = prefab;
        }

        public void AddUIElementToUIContainer (GameObject gameObject)
        {
            if (gameObject.TryGetComponent(out  RectTransform rectTransform))
            {
                _container.AddComponent(rectTransform);
            }

            else
            {
                throw new NullReferenceException($"GameObject {gameObject.name} not have component {nameof(RectTransform)}");
            }
        }
    }
}
