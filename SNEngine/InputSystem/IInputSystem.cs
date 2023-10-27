using UnityEngine.Events;
using UnityEngine;

namespace SNEngine.InputSystem
{
    public interface IInputSystem
    {
        void AddListener(UnityAction<KeyCode> action, StandaloneInputEventType eventType);

        void RemoveListener(UnityAction<KeyCode> action, StandaloneInputEventType eventType);

        void AddListener(UnityAction<Touch> action, MobileInputEventType eventType);

        void RemoveListener(UnityAction<Touch> action, MobileInputEventType eventType);
    }
}
