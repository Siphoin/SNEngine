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
            var mCamera = _camera;

            Rect rect = new Rect(0, 0, mCamera.pixelWidth, mCamera.pixelHeight);
            RenderTexture renderTexture = new RenderTexture(mCamera.pixelWidth, mCamera.pixelHeight, 24);
            Texture2D screenShot = new Texture2D(mCamera.pixelWidth, mCamera.pixelHeight, TextureFormat.RGBA32, false);

            mCamera.targetTexture = renderTexture;

            RenderTexture.active = renderTexture;

            mCamera.Render();

            screenShot.ReadPixels(rect, 0, 0);
            screenShot.Apply();






            return screenShot;
        }

        public void Clear()
        {
            _camera.targetTexture = null;
            RenderTexture.active = null;
        }
    }
}