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
        private const string PROPERTY_SHADER_DISSOLVE_RANGE_VALUE = "_DissolveValue";

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

        public static Sequence DODissolve(this SpriteRenderer spriteRenderer, AnimationBehaviourType animationBehaviour, float duration, Texture2D texture = null)
        {
            float endValue = animationBehaviour == AnimationBehaviourType.In ? 1 : 0;

            Material dissolve = NovelGame.GetRepository<MaterialRepository>().GetMaterial("dissolve");

            if (!spriteRenderer.material.HasFloat(PROPERTY_SHADER_DISSOLVE_RANGE_VALUE))
            {
                spriteRenderer.material = new Material(dissolve);
            }

            if (texture != null)
            {
                spriteRenderer.material.SetTexture("_DissolveTex", texture);
            }

            Sequence sequence = DOTween.Sequence();

            sequence.Append(spriteRenderer.material.DOFloat(endValue, PROPERTY_SHADER_DISSOLVE_RANGE_VALUE, duration));

            if (animationBehaviour == AnimationBehaviourType.Out)
            {
               ReturnMaterialToSpriteRenderer(spriteRenderer, duration).Forget();
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
