using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;

namespace SNEngine.SelectVariantsSystem
{
    [RequireComponent(typeof(Button))]
    public class VariantButton : MonoBehaviour, IVariantButton
    {
        [SerializeField, Min(0.1f)] private float _speedAnimation = 0.5f;

        private AnimationButtonsType _currentAnimationType;

        

        [SerializeField] private TextMeshProUGUI _textButton;

        [SerializeField] private Ease _easeAnimation = Ease.Linear;


        private Button _button;

        private Image _image;

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

            if (!TryGetComponent(out _image))
            {
                throw new NullReferenceException("image component is null");
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

            CheckAnimationOption();

        }

        private void CheckAnimationOption()
        {
            string animationType = _currentAnimationType.ToString();

            if (animationType.Contains(nameof(Fade)))
            {
                Fade();
            }


            else if (animationType.Contains(nameof(Scale)))
            {
                Scale();
            }
        }

        private void Select()
        {
            int index = transform.GetSiblingIndex();

            OnSelect?.Invoke(index);
        }

        public void SetData(string data, AnimationButtonsType animationType)
        {
            _textButton.text = data;

            _currentAnimationType = animationType;
        }

        #region Animations

        #region Fading

        private void Fade()
        {
            _image.DOFade(0, 0).SetEase(_easeAnimation);

            _textButton.DOFade(0, 0).SetEase(_easeAnimation);

            switch (_currentAnimationType)
            {
                case AnimationButtonsType.Fade:
                    PlayFade();
                    break;
                case AnimationButtonsType.FadeQueue:
                    PlayAnimationWithQueue(PlayFade).Forget();
                    break;
            }
        }

        private void PlayFade()
        {
            _image.DOFade(1, _speedAnimation).SetEase(_easeAnimation);

            _textButton.DOFade(1, _speedAnimation).SetEase(_easeAnimation);
        }


        #endregion

        #region Scaling
        private void Scale ()
        {
            transform.localScale = Vector3.zero;

            switch (_currentAnimationType)
            {
                case AnimationButtonsType.Scale:
                    PlayScale();
                    break;
                case AnimationButtonsType.ScaleQueue:
                    PlayAnimationWithQueue(PlayScale).Forget();
                    break;
            }
        }

        private void PlayScale ()
        {
            transform.DOScale(Vector3.one, _speedAnimation).SetEase(_easeAnimation);
        }
        #endregion

        private async UniTask PlayAnimationWithQueue(Action action)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(transform.GetSiblingIndex() / 10f + (_speedAnimation));

            await UniTask.Delay(timeSpan);

            action.Invoke();
        }
        #endregion
    }
}