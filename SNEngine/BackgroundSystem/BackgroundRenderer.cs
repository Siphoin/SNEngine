using Cysharp.Threading.Tasks;
using DG.Tweening;
using SNEngine.Animations;
using SNEngine.Extensions;
using System;
using UnityEngine;

namespace SNEngine.BackgroundSystem
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class BackgroundRenderer : MonoBehaviour, IBackgroundRenderer
    {
        private SpriteRenderer _spriteRenderer;

        protected SpriteRenderer SpriteRenderer => _spriteRenderer;

        public void SetData(Sprite data)
        {
            _spriteRenderer.sprite = data;
        }

        public void Clear ()
        {
            _spriteRenderer.sprite = null;
        }

        public void SetFlip(FlipType flipType)
        {
            _spriteRenderer.Flip(flipType);
        }

        private void Awake()
        {
            if (!TryGetComponent(out _spriteRenderer))
            {
                throw new NullReferenceException("sprite renderer component not found on background renderer");
            }
        }

        public void ResetState()
        {
            Clear();

            _spriteRenderer.color = Color.white;

            transform.position = Vector3.zero;

            SetFlip(FlipType.None);
        }

        #region Animations
        public async UniTask Fade(float value, float time, Ease ease)
        {
            value = Mathf.Clamp01(value);

            time = MathfExtensions.ClampTime(time);

            await _spriteRenderer.DOFade(value, time).SetEase(ease);
        }

        public async UniTask ChangeColor(Color color, float time, Ease ease)
        {
            time = MathfExtensions.ClampTime(time);

            await _spriteRenderer.DOColor(color, time).SetEase(ease);
        }
        #endregion
    }
}