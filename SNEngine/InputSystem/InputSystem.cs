using SNEngine.Debugging;
using SNEngine.Extensions;
using System;
using UnityEngine;
using UnityEngine.Events;

namespace SNEngine.InputSystem
{
    public class InputSystem : MonoBehaviour, IInputSystem
    {
#if UNITY_STANDALONE
        private event UnityAction<KeyCode>  OnKeyUp;

        private event UnityAction<KeyCode> OnKeyDown;

        private event UnityAction<KeyCode> OnKey;

        private Array _keyCodes;
#endif

#if UNITY_ANDROID || UNITY_IOS
        private event UnityAction<Touch> OnTouchBegan;

        private event UnityAction<Touch> OnTouchCanceled;

        private event UnityAction<Touch> OnTouchEnded;

        private event UnityAction<Touch> OnTouchMoved;

        private event UnityAction<Touch> OnTouchStationary;
#endif

        private void Awake()
        {
#if UNITY_STANDALONE
            _keyCodes = Enum.GetValues(typeof(KeyCode));

            Log("Enabled Standalone Input");
#endif

#if UNITY_ANDROID || UNITY_IOS
            Log("Enabled Mobile Input");
#endif
        }


    private void Update()
        {
            #region Standalone Input

#if UNITY_STANDALONE

            ListeringKeyCodes();
#endif

            #endregion

            #region Mobile Input

#if UNITY_ANDROID || UNITY_IOS
            ListeringTouch();

#endif

            #endregion


        }

#if UNITY_STANDALONE
        private void ListeringKeyCodes()
        {
            if (Input.anyKeyDown && OnKeyDown.IsHaveSubcribe())
            {
                foreach (KeyCode keyCode in _keyCodes)
                {
                    if (Input.GetKeyDown(keyCode))
                    {
                        OnKeyDown?.Invoke(keyCode);
                    }
                }
            }

            if (Input.anyKey && OnKeyUp.IsHaveSubcribe() || OnKey.IsHaveSubcribe())
            {
                foreach (KeyCode keyCode in _keyCodes)
                {
                    if (Input.GetKey(keyCode))
                    {
                        OnKey?.Invoke(keyCode);
                    }

                    if (Input.GetKeyUp(keyCode))
                    {
                        OnKeyUp?.Invoke(keyCode);
                    }
                }
            }
        }
#endif

#if UNITY_ANDROID || UNITY_IOS
        private void ListeringTouch()
        {
            if (Input.touchCount > 0)
            {
                var touches = Input.touches;
                foreach (var touch in touches)
                {
                    switch (touch.phase)
                    {
                        case TouchPhase.Began:
                            OnTouchBegan?.Invoke(touch);
                            break;
                        case TouchPhase.Moved:
                            OnTouchMoved?.Invoke(touch);
                            break;
                        case TouchPhase.Stationary:
                            OnTouchStationary?.Invoke(touch);
                            break;
                        case TouchPhase.Ended:
                            OnTouchEnded?.Invoke(touch);
                            break;
                        case TouchPhase.Canceled:
                            OnTouchCanceled?.Invoke(touch);
                            break;
                    }
                }
            }
        }

#endif

        public void AddListener (UnityAction<KeyCode> action, StandaloneInputEventType eventType)
        {
            AddListener(eventType, action);
        }

        public void RemoveListener(UnityAction<KeyCode> action, StandaloneInputEventType eventType)
        {
            RemoveListener(eventType, action);

        }
        private void AddListener (StandaloneInputEventType eventType, UnityAction<KeyCode> observer)
        {
#if UNITY_STANDALONE
            try
            {
                switch (eventType)
                {
                    case StandaloneInputEventType.KeyDown:
                        OnKeyDown += observer;

                        Log(observer, eventType, nameof(AddListener));
                        break;
                    case StandaloneInputEventType.KeyUp:
                        OnKeyUp += observer;

                        Log(observer, eventType, nameof(AddListener));
                        break;
                    case StandaloneInputEventType.KeyPressing:
                        OnKey += observer;

                        Log(observer, eventType, nameof(AddListener));
                        break;
                    default:
                        break;
                }
            }
            catch 
            {

            }
#endif

        }

        private void RemoveListener(StandaloneInputEventType eventType, UnityAction<KeyCode> observer)
        {
#if UNITY_STANDALONE
            try
            {
                switch (eventType)
                {
                    case StandaloneInputEventType.KeyDown:
                        OnKeyDown -= observer;

                        Log(observer, eventType, nameof(RemoveListener));
                        break;
                    case StandaloneInputEventType.KeyUp:
                        OnKeyUp -= observer;

                        Log(observer, eventType, nameof(RemoveListener));
                        break;
                    case StandaloneInputEventType.KeyPressing:
                        OnKey -= observer;

                        Log(observer, eventType, nameof(RemoveListener));

                        break;
                    default:
                        break;
                }
            }
            catch
            {

            }
#endif
        }
        public void AddListener(UnityAction<Touch> action, MobileInputEventType eventType)
        {
#if UNITY_ANDROID || UNITY_IOS
            try
            {
                switch (eventType)
                {
                    case MobileInputEventType.TouchBegan:
                        OnTouchBegan += action;

                        Log(action, eventType, nameof(AddListener));
                        break;
                    case MobileInputEventType.TouchCanceled:
                        OnTouchCanceled += action;

                        Log(action, eventType, nameof(AddListener));
                        break;
                    case MobileInputEventType.TouchEnded:
                        OnTouchEnded += action;

                        Log(action, eventType, nameof(AddListener));
                        break;
                    case MobileInputEventType.TouchMoved:
                        OnTouchMoved += action;

                        Log(action, eventType, nameof(AddListener));
                        break;
                    case MobileInputEventType.TouchStationary:
                        OnTouchStationary += action;

                        Log(action, eventType, nameof(AddListener));
                        break;
                    default:
                        break;
                }
            }
            catch
            {

            }

#endif
        }

        public void RemoveListener(UnityAction<Touch> action, MobileInputEventType eventType)
        {
#if UNITY_ANDROID || UNITY_IOS
            try
            {
                switch (eventType)
                {
                    case MobileInputEventType.TouchBegan:
                        OnTouchBegan -= action;

                        Log(action, eventType, nameof(RemoveListener));
                        break;
                    case MobileInputEventType.TouchCanceled:
                        OnTouchCanceled -= action;

                        Log(action, eventType, nameof(RemoveListener));
                        break;
                    case MobileInputEventType.TouchEnded:
                        OnTouchEnded -= action;

                        Log(action, eventType, nameof(RemoveListener));
                        break;
                    case MobileInputEventType.TouchMoved:
                        OnTouchMoved -= action;

                        Log(action, eventType, nameof(RemoveListener));
                        break;
                    case MobileInputEventType.TouchStationary:
                        OnTouchStationary -= action;

                        Log(action, eventType, nameof(RemoveListener));
                        break;
                    default:
                        break;
                }
            }
            catch
            {

            }

#endif
        }
#if UNITY_STANDALONE
        private void Log (UnityAction<KeyCode> action, StandaloneInputEventType eventType, string message)
        {
            Log($"{message}:Target Event: <b>On{eventType}</b> Observer: <b>{action.Target.GetType().Name}</b>");
        }
#endif

#if UNITY_ANDROID || UNITY_IOS
        private void Log(UnityAction<Touch> action, MobileInputEventType eventType, string message)
        {
            Log($"{message}:Target Event: <b>On{eventType}</b> Observer: <b>{action.Target.GetType().Name}</b>");
        }
#endif

        private void Log (string message)
        {
            NovelGameDebug.Log($"<color=#baa229>{nameof(InputSystem)}:</color> <b>{message}</b>.");
        }
    }
}