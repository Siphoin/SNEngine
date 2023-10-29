using SNEngine.Animations;
using SNEngine.Repositories;
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

        public static void ReturnDefaultMaterial (this SpriteRenderer spriteRenderer)
        {
            var material = NovelGame.GetRepository<MaterialRepository>().GetMaterial("default");

            spriteRenderer.material = material;
        }
    }
}
