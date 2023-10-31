using UnityEngine;
using System;

namespace SNEngine
{
    [RequireComponent(typeof(SpriteRenderer))]
    public class OldRenderDialogue : MonoBehaviour, IOldRenderDialogue
    {
        private SpriteRenderer _spriteRenderer;

        private Camera _camera;

        private void Awake()
        {
            if (!TryGetComponent(out _spriteRenderer))
            {
                throw new NullReferenceException("sprite renderer null");
            }

            _camera = Camera.main;
        }

        public Texture2D UpdateRender()
        {
            _camera.Render();

            Texture2D texture = new Texture2D(_camera.pixelWidth, _camera.pixelHeight);

            texture.ReadPixels(new Rect(0, 0, _camera.pixelWidth, _camera.pixelHeight), 0, 0);

            texture.Apply();

            _spriteRenderer.sprite = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), Vector2.zero);

            return texture;
        }

        public void Clear()
        {
            _spriteRenderer = null;
        }
    }
}