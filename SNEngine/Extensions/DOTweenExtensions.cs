using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using DG.Tweening;
using UnityEngine;
using SNEngine.Animations;
using Cysharp.Threading.Tasks;
using System;
using SNEngine.Debugging;
using SNEngine.Repositories;

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

        public static Sequence DODissolve(this SpriteRenderer spriteRenderer, AnimationBehaviourType animationBehaviour, float duration)
        {
            float endValue = animationBehaviour == AnimationBehaviourType.In ? 1 : 0;

            Material dissolve = NovelGame.GetRepository<MaterialRepository>().GetMaterial("dissolve");

            if (!spriteRenderer.material.HasFloat("_DissolveValue"))
            {
                spriteRenderer.material = dissolve;
            }

            Sequence sequence = DOTween.Sequence();

            sequence.Append(spriteRenderer.material.DOFloat(endValue, "_DissolveValue", duration));

            if (animationBehaviour == AnimationBehaviourType.Out)
            {
               ReturnMaterialToSpriteRenderer(spriteRenderer, duration * 2).Forget();
            }
            return sequence.Play();

            
        }

        private static async UniTask ReturnMaterialToSpriteRenderer (SpriteRenderer spriteRenderer, float timeOut)
        {
            TimeSpan timeSpan = TimeSpan.FromSeconds(timeOut);

            await UniTask.Delay(timeSpan);

            spriteRenderer.ReturnDefaultMaterial();

            NovelGameDebug.Log($"Return material {spriteRenderer.material.name} to Sprite Renderer {spriteRenderer.gameObject.name}");
        }
    }
}
