using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using DG.Tweening;
using UnityEngine;
using SNEngine.Animations;
using Cysharp.Threading.Tasks;
using System;
using SNEngine.Debugging;

namespace SNEngine.Extensions
{
    public static class DOTweenExtensions
    {
        public static TweenerCore<Vector3, Vector3, VectorOptions> DOParalax(this Transform target, Direction direction, float duration, bool snapping = false)
        {
            Vector3 endValue = target.position;

            target.position = target.GetScreenEdge(direction);



            TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = DOTween.To(() => target.position, delegate (Vector3 x)
            {
                target.position = x;
            }, endValue, duration);
            tweenerCore.SetOptions(snapping).SetTarget(target);
            return tweenerCore;
        }

        public static TweenerCore<Color, Color, ColorOptions> DODissolve(this SpriteRenderer spriteRenderer, float duration)
        {
            Color colorStart = spriteRenderer.color;

            colorStart.a = 0.5f;

            spriteRenderer.color = colorStart;

           return spriteRenderer.DOFade(1, duration);
        }
    }
}
