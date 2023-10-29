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

        #region Animations
        public async UniTask Move(float x, float time, Ease ease)
        {
            time = MathfExtensions.ClampTime(time);

            await transform.DOMoveX(x, time).SetEase(ease);
        }

        public async UniTask Fade(float value,  float time, Ease ease)
        {
            time = MathfExtensions.ClampTime(time);

            value = Mathf.Clamp01(value);

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

        #endregion

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
    }
}