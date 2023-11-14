using UnityEngine;
using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using SNEngine.Extensions;
using SNEngine.Animations;
using SNEngine.Repositories;

namespace SNEngine.CharacterSystem
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class CharacterRenderer : MonoBehaviour, ICharacterRenderer
    {
        private SpriteRenderer _spriteRenderer;

        private Character _character;

        private Material _defaultMaterial;

        private void Awake()
        {
            if (!TryGetComponent(out _spriteRenderer))
            {
                throw new NullReferenceException("sprite renderer component not found on character renderer");
            }

            _defaultMaterial = NovelGame.GetRepository<MaterialRepository>().GetMaterial("default");


        }
        public void Hide()
        {
            gameObject.SetActive(false);
        }

        public void Show()
        {
            gameObject.SetActive(true);

            CalculatePositionForScreen();
        }

        public void SetData(Character data)
        {
            if (data is null)
            {
                throw new ArgumentNullException("data character is null");
            }

            _character = data;
        }

        public void ShowWithEmotion (string emotionName = "Default")
        {
            _spriteRenderer.sprite = _character.GetEmotion(emotionName).Sprite;

            Show();
        }

        public void SetFlip(FlipType flipType)
        {
            _spriteRenderer.Flip(flipType);
        }

        private void CalculatePositionForScreen ()
        {
            float spriteHeight = _spriteRenderer.bounds.size.y;

            float screenHeight = Camera.main.orthographicSize * 2;

            float newPositionY = -screenHeight / 2 + spriteHeight / 2;

            transform.position = new Vector3(transform.position.x, newPositionY, transform.position.z);
        }

        public void ResetState()
        {
            Vector3 position = transform.position;

            position.x = 0;

            transform.position = position;

            transform.localScale = Vector3.one;
            
            transform.localRotation = Quaternion.identity;

            transform.rotation = Quaternion.identity;

            _spriteRenderer.sprite = _character.GetEmotion(0).Sprite;

            _spriteRenderer.color = Color.white;

            _spriteRenderer.flipX = false;

            _spriteRenderer.flipY = false;

            _spriteRenderer.material = _defaultMaterial;

            SetFlip(FlipType.None);

            Hide();
        }

        #region Animations
        public async UniTask Move(float x, float time, Ease ease)
        {
            time = MathfExtensions.ClampTime(time);

            await transform.DOMoveX(x, time).SetEase(ease);
        }


        public async UniTask Move(CharacterDirection direction, float time, Ease ease)
        {
            float spriteSizeX = _spriteRenderer.size.x;

            float cameraBorder = Camera.main.aspect * Camera.main.orthographicSize - spriteSizeX / 2;

            float x = direction == CharacterDirection.Left ? -cameraBorder : cameraBorder;

            await transform.DOMoveX(x, time).SetEase(ease);

        }

        public async UniTask Fade(float value, float time, Ease ease)
        {
            time = MathfExtensions.ClampTime(time);

            value = Mathf.Clamp01(value);

            await _spriteRenderer.DOFade(value, time).SetEase(ease);
        }

        public async UniTask Fade(float time, AnimationBehaviourType animationBehaviour, Ease ease)
        {
            time = MathfExtensions.ClampTime(time);

            float value = AnimationBehaviourHelper.GetValue(animationBehaviour);

            await _spriteRenderer.DOFade(value, time).SetEase(ease);
        }

        public async UniTask Scale(Vector3 scale, float time, Ease ease)
        {
            time = MathfExtensions.ClampTime(time);

            await transform.DOScale(scale, time).SetEase(ease);
        }

        public async UniTask Rotate(Vector3 angle, float time, Ease ease, RotateMode rotateMode)
        {
            time = MathfExtensions.ClampTime(time);

            await transform.DOLocalRotate(angle, time, rotateMode).SetEase(ease);
        }

        public async UniTask ChangeColor(Color color, float time, Ease ease)
        {
            time = MathfExtensions.ClampTime(time);

            await _spriteRenderer.DOColor(color, time).SetEase(ease);
        }

        public async UniTask Dissolve(float time, AnimationBehaviourType animationBehaviour, Ease ease, Texture2D texture = null)
        {
            time = MathfExtensions.ClampTime(time);

            await _spriteRenderer.DODissolve(animationBehaviour, time, texture).SetEase(ease);
        }

        public async UniTask ToBlackAndWhite(float time, AnimationBehaviourType animationBehaviour, Ease ease)
        {
            time = MathfExtensions.ClampTime(time);

            await _spriteRenderer.DOBlackAndWhite(animationBehaviour, time).SetEase(ease);
        }

        public async UniTask ToBlackAndWhite(float time, float value, Ease ease)
        {
            time = MathfExtensions.ClampTime(time);

            await _spriteRenderer.DOBlackAndWhite(value, time).SetEase(ease);
        }

        public async UniTask Celia(float time, AnimationBehaviourType animationBehaviour, Ease ease)
        {
            time = MathfExtensions.ClampTime(time);

            await _spriteRenderer.DOCelia(animationBehaviour, time).SetEase(ease);
        }

        public async UniTask Celia(float time, float value, Ease ease)
        {
            time = MathfExtensions.ClampTime(time);

            await _spriteRenderer.DOCelia(value, time).SetEase(ease);
        }

        public async UniTask Solid(float time, AnimationBehaviourType animationBehaviour, Ease ease)
        {
            time = MathfExtensions.ClampTime(time);

            await _spriteRenderer.DOSolid(animationBehaviour, time).SetEase(ease);
        }

        public async UniTask Solid(float time, float value, Ease ease)
        {
            time = MathfExtensions.ClampTime(time);

            await _spriteRenderer.DOSolid(value, time).SetEase(ease);
        }

        public async UniTask Illuminate(float time, AnimationBehaviourType animationBehaviour, Ease ease)
        {
            time = MathfExtensions.ClampTime(time);

            await _spriteRenderer.DOIllumination(animationBehaviour, time).SetEase(ease);
        }

        public async UniTask Illuminate(float time, float value, Ease ease)
        {
            time = MathfExtensions.ClampTime(time);

            await _spriteRenderer.DOIllumination(value, time).SetEase(ease);
        }

        #endregion
    }
}