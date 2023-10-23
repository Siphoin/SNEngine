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
        }
    }
}