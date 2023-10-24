using SNEngine.Animations;
using UnityEngine;

namespace SNEngine.Extensions
{
    public static class SpriteRendererExtensions
    {
        public static void Flip (this SpriteRenderer spriteRenderer, FlipType flipType)
        {
            switch (flipType)
            {
                case FlipType.None:
                    spriteRenderer.flipX = false;

                    spriteRenderer.flipY = false;
                    break;
                case FlipType.X:
                    spriteRenderer.flipX = true;

                    spriteRenderer.flipY = false;
                    break;
                case FlipType.Y:
                    spriteRenderer.flipY = true;

                    spriteRenderer.flipX = false;
                    break;
                case FlipType.XY:
                    spriteRenderer.flipX = true;

                    spriteRenderer.flipY = true;
                    break;
            }
        }
    }
}
