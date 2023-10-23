using UnityEngine;
using System;
using Cysharp.Threading.Tasks;
using DG.Tweening;

namespace SNEngine.CharacterSystem
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class CharacterRenderer : MonoBehaviour, ICharacterRenderer
    {
        private SpriteRenderer _spriteRenderer;

        private Character _character;

        private void Awake()
        {
            if (!TryGetComponent(out _spriteRenderer))
            {
                throw new NullReferenceException("sprite renderer component not found on character renderer");
            }

            
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

        public void SetFlipX (bool flipX)
        {
            _spriteRenderer.flipX = flipX;
        }

        private void CalculatePositionForScreen ()
        {
            float spriteHeight = _spriteRenderer.bounds.size.y;

            float screenHeight = Camera.main.orthographicSize * 2;

            float newPositionY = -screenHeight / 2 + spriteHeight / 2;

            transform.position = new Vector3(transform.position.x, newPositionY, transform.position.z);
        }

        #region Animations

        private float ClampTime (float time)
        {
            return Mathf.Clamp(time, 0, float.MaxValue);
        }
        public async UniTask Move(float x, float time)
        {
            time = ClampTime(time);

            await transform.DOMoveX(x, time);
        }

        public async UniTask Fade(float value,  float time)
        {
            time = ClampTime(time);

            value = Mathf.Clamp01(value);

            await _spriteRenderer.DOFade(value, time);
        }

        public async UniTask Scale (Vector3 scale, float time)
        {
            time = ClampTime(time);

            await transform.DOScale(scale, time);
        }

        public async UniTask Rotate(Vector3 angle, float time, RotateMode rotateMode)
        {
            time = ClampTime(time);

            await transform.DORotate(angle, time, rotateMode);
        }

        #endregion

        public void ResetState()
        {
            _spriteRenderer.DOFade(1, 0);

            Vector3 position = transform.position;

            position.x = 0;

            transform.position = position;

            transform.localScale = Vector3.one;
            
            transform.localRotation = Quaternion.identity;

            transform.rotation = Quaternion.identity;

            _spriteRenderer.sprite = _character.GetEmotion().Sprite;

            Hide();
        }
    }
}