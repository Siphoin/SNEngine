using Cysharp.Threading.Tasks;
using DG.Tweening;
using SNEngine.Animations;
using SNEngine.Debugging;
using SNEngine.Extensions;
using System;
using UnityEngine;

namespace SNEngine.BackgroundSystem
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class BackgroundRenderer : MonoBehaviour, IBackgroundRenderer
    {
       public bool UseTransition { get; set; }

        [SerializeField] private SpriteRenderer _maskTransition;

        private Sprite _oldSetedBackground;

        private SpriteRenderer _spriteRenderer;

        protected SpriteRenderer SpriteRenderer => _spriteRenderer;

        public void SetData(Sprite data)
        {
            if (_maskTransition != null)
            {
                _maskTransition.sprite = _spriteRenderer.sprite;
            }

            _oldSetedBackground = _spriteRenderer.sprite;

            UpdateBackground(data).Forget();
        }

        private async UniTask UpdateBackground(Sprite data)
        {
            await UniTask.WaitForEndOfFrame(this);

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

            if (_maskTransition != null)
            {
                _maskTransition.ReturnDefaultMaterial();

                SetVisibleMaskTransition(false);
            }
        }

        private void SetVisibleMaskTransition(bool visible)
        {
            if (!_maskTransition)
            {
                NovelGameDebug.LogError($"The Background Renderer {name} not have mask transition");

                return;
            }

            _maskTransition.gameObject.SetActive(visible);
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

        public async UniTask Move(Direction direction, float time, Ease ease)
        {
            time = MathfExtensions.ClampTime(time);

            await transform.DOParalax(direction, time);
        }

        public async UniTask Dissolve(float time, AnimationBehaviourType animationBehaviour, Ease ease, Texture2D texture = null)
        {
            time = MathfExtensions.ClampTime(time);

            if (!UseTransition)
            {
                await _spriteRenderer.DODissolve(animationBehaviour, time, texture).SetEase(ease);
            }

            else
            {
                SetVisibleMaskTransition(true);

                await _maskTransition.DODissolve(animationBehaviour, time, texture).SetEase(ease);

                SetVisibleMaskTransition(false);

                if (animationBehaviour == AnimationBehaviourType.In)
                {
                    _maskTransition.material.SetFloat("_DissolveValue", 0);
                }

                

                UseTransition = false;
            }
        }



        #endregion
    }
}