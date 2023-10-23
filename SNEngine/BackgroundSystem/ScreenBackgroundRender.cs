using UnityEngine;

namespace SNEngine.BackgroundSystem
{
    public class ScreenBackgroundRender : BackgroundRenderer
    {
        void OnGUI()
        {
            float screenWidth = Screen.width;
            float screenHeight = Screen.height;

            float spriteWidth = SpriteRenderer.sprite.bounds.size.x;
            float spriteHeight = SpriteRenderer.sprite.bounds.size.y;

            float scaleX = screenWidth / spriteWidth;
            float scaleY = screenHeight / spriteHeight;

            transform.localScale = new Vector3(scaleX, scaleY, 1);
        }
    }
}
