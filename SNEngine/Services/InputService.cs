using SNEngine.InputSystem;
using UnityEngine;
using UnityEngine.Events;

namespace SNEngine.Services
{
    public class InputService : IService, IInputSystem
    {
        private IInputSystem _input;
        public void Initialize()
        {
            var input = Resources.Load<InputSystem.InputSystem>("System/Input/InputSystem");

            var prefab = Object.Instantiate(input);

            prefab.name = input.name;

            Object.DontDestroyOnLoad(prefab);

            _input = prefab;
        }

        public void AddListener(UnityAction<KeyCode> action, StandaloneInputEventType eventType)
        {
            _input.AddListener(action, eventType);
        }

        public void RemoveListener(UnityAction<KeyCode> action, StandaloneInputEventType eventType)
        {
            _input.RemoveListener(action, eventType);
        }

        public void AddListener(UnityAction<Touch> action, MobileInputEventType eventType)
        {
            _input.AddListener(action, eventType);
        }

        public void RemoveListener(UnityAction<Touch> action, MobileInputEventType eventType)
        {
            _input.RemoveListener(action, eventType);
        }
    }
}
