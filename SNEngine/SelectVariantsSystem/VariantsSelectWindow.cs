using SNEngine.Polling;
using UnityEngine;
using System;
using System.Collections.Generic;
using SNEngine.Debugging;
using UnityEngine.UI;
using SNEngine.Services;
using SiphoinUnityHelpers.XNodeExtensions.Attributes;
using System.Linq;

namespace SNEngine.SelectVariantsSystem
{
    [RequireComponent(typeof(RectTransform))]
    public class VariantsSelectWindow : MonoBehaviour, IVariantsSelectWindow
    {
        private int RESIZE_IF_BUTTONS_BETWEEN = 5;

        private bool _returnCharactersVisible;

        private PoolMono<VariantButton> _pool;

        private RectTransform _rectTransform;

        private RectTransform _rectTransformScroll;

        private Vector3 _defaultSizeDeltaScrool;

        private Vector3 _defaultPositionScroll;

        [SerializeField, ReadOnly(ReadOnlyMode.OnEditor)] private VariantButton _buttonPrefab;

        [SerializeField, ReadOnly(ReadOnlyMode.OnEditor)] private ScrollRect _scrollRect;

        [SerializeField, ReadOnly(ReadOnlyMode.OnEditor)] private Transform _container;

        

        [Space]

        [SerializeField, Min(2)] private int _buttonsCreatedOnStart = 5;

        public event Action<int> OnSelect;

        private void Awake()
        {
            if (!_container)
            {
                _container = transform;
            }

            if (!TryGetComponent(out _rectTransform))
            {
                throw new NullReferenceException("rect transform null");
            }

            if (!_scrollRect.TryGetComponent(out _rectTransformScroll))
            {
                throw new NullReferenceException("scroll rect rect transform component not found");
            }

            _pool = new PoolMono<VariantButton>(_buttonPrefab, _container, _buttonsCreatedOnStart, true);

            _defaultSizeDeltaScrool = _rectTransformScroll.sizeDelta;

            _defaultPositionScroll = _rectTransformScroll.localPosition;
        }

        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void SetData(IEnumerable<string> data, AnimationButtonsType animationType)
        {
            var strings = data.ToArray();
            foreach (var item in strings)
            {
                var button = _pool.GetFreeElement();

                button.SetData(item, animationType);

                button.OnSelect += OnSelectVariant;

                button.Show();
            }

            if (strings.Length >= RESIZE_IF_BUTTONS_BETWEEN)
            {

                // Устанавливаем позицию scroolrect по нулям
                _rectTransformScroll.localPosition = Vector3.zero;

                // Расширяем ширину и высоту scroolrect до размеров родителя
                _rectTransformScroll.sizeDelta = _rectTransform.sizeDelta;
            }

            else
            {
                _rectTransformScroll.localPosition = _defaultPositionScroll;

                _rectTransformScroll.sizeDelta = _defaultSizeDeltaScrool;
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

            if (_returnCharactersVisible)
            {
                var charactersService = NovelGame.GetService<CharacterService>();

                charactersService.ShowInvolvedCharacters();
            }

            Hide();
        }

        public void Show()
        {
            gameObject.SetActive(true);
        }

        public void ShowVariants(IEnumerable<string> variants, bool hideCharacters = true, bool hideDialogWindow = true, bool returnCharactersVisible = true, AnimationButtonsType animationType = AnimationButtonsType.None)
        {
           

            if (hideDialogWindow)
            {
                var dialogUIService = NovelGame.GetService<DialogueUIService>();

                dialogUIService.HideDialog();
            }

            if (hideCharacters)
            {
                var charactersService = NovelGame.GetService<CharacterService>();

                charactersService.HideInvolvedCharacters();
            }

            _returnCharactersVisible = returnCharactersVisible;

            Show();

            SetData(variants, animationType);
        }
    }
}