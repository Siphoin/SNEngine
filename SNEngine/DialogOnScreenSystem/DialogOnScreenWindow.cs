using Cysharp.Threading.Tasks;
using UnityEngine.UI;
using UnityEngine;
using DG.Tweening;
using System;
using SNEngine.Debugging;

namespace SNEngine.DialogOnScreenSystem
{
    public class DialogOnScreenWindow : PrinterText, IDialogOnScreenWindow
    {
        private IDialogOnScreenNode _dialog;

        private ScrollRect _scrollRect;

        [SerializeField, Min(0)] private float _durationScroolToDown;

        [SerializeField] private Ease _ease = Ease.Linear;

       

        protected override void Awake()
        {
            base.Awake();

            if (!TryGetComponent(out _scrollRect))
            {
                throw new NullReferenceException("scroll rect for dialog on screen window is null");
            }
        }
        public void SetData(IDialogOnScreenNode dialog)
        {
            _dialog = dialog;
        }

        public void StartOutputDialog()
        {
            if (_dialog is null)
            {
                NovelGameDebug.LogError("dialog on screen node is null. Check your Graph");

                return;
            }

            StartOutputDialog(_dialog.GetText());

            NormalixationScroll().Forget();
        }

        protected override async UniTask Writing(string message)
        {     
            await base.Writing(message);
        }

        private async UniTask  NormalixationScroll()
        {
            while (!AllTextWrited && Application.isPlaying)
            {
                if (_scrollRect.content.rect.height > _scrollRect.viewport.rect.height)
                {
                    await ToDownScroll();
                }
                await UniTask.Yield();
            }
        }

        private async UniTask ToDownScroll()
        {
            Vector3 normalizedPosition = GetDownNormalizedPositionScrooll();

            await NormalizeScrool(normalizedPosition, _durationScroolToDown);
        }

        private Vector3 GetDownNormalizedPositionScrooll()
        {
            RectTransform viewport = _scrollRect.viewport;

            RectTransform content = _scrollRect.content;

            Vector3 normalizedPosition = new Vector3(1 - (content.rect.height - viewport.rect.height) / content.rect.height, 0, 0);

            return normalizedPosition;
        }

        protected override void EndWrite()
        {
            base.EndWrite();

            Vector3 normalizedPosition = GetDownNormalizedPositionScrooll();

            NormalizeScrool(normalizedPosition).Forget();

        }

        private async UniTask NormalizeScrool(Vector3 normalizedPosition, float time = 0)
        {
            await _scrollRect.DONormalizedPos(normalizedPosition, time).SetEase(_ease);
        }
    }
}