using SNEngine.UI;
using UnityEngine;
using System;
using Object = UnityEngine.Object;
using UnityEngine.EventSystems;

namespace SNEngine.Services
{
    public class UIService : IService
    {
        private IUIContainer _container;
        public void Initialize()
        {
            LoadEventSystem();

            LoadContainer();
        }

        private T LoadUIElement<T> () where T : Component
        {
            Type type = typeof(T);

            var element = Resources.Load<T>($"UI/{type.Name}");

            var prefab = Object.Instantiate(element);

            prefab.name = element.name;

            Object.DontDestroyOnLoad(prefab);

            return prefab;
        }

        private void LoadEventSystem()
        {
            LoadUIElement<EventSystem>();
        }

        private void LoadContainer()
        {
            _container = LoadUIElement<UIContainer>();
        }

        public void AddElementToUIContainer (GameObject gameObject)
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
