using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;
using DG.Tweening;
using UnityEngine;
using SNEngine.Animations;

namespace SNEngine.Extensions
{
    public static class DOTweenExtensions
    {
        public static TweenerCore<Vector3, Vector3, VectorOptions> DOParalax(this Transform target, Direction direction, float duration, bool snapping = false)
        {
            Vector3 endValue = target.position;

            target.position = GetScreenEdge(target, direction);



            TweenerCore<Vector3, Vector3, VectorOptions> tweenerCore = DOTween.To(() => target.position, delegate (Vector3 x)
            {
                target.position = x;
            }, endValue, duration);
            tweenerCore.SetOptions(snapping).SetTarget(target);
            return tweenerCore;
        }

        private static Vector3 GetScreenEdge (Transform transform, Direction direction)
        {
            Vector3 position = Vector3.zero;

            float orthographicSize = Camera.main.orthographicSize;

            float cameraAspect = Camera.main.aspect;

            switch (direction)
            {
                case Direction.Up:
                    position = new Vector3(transform.position.x, orthographicSize, transform.position.z);
                    break;
                case Direction.Down:
                    position = new Vector3(transform.position.x, -orthographicSize, transform.position.z);
                    break;
                case Direction.Left:
                    position = new Vector3(-cameraAspect * orthographicSize, transform.position.y, transform.position.z);
                    break;
                case Direction.Right:
                    position = new Vector3(cameraAspect * orthographicSize, transform.position.y, transform.position.z);
                    break;
            }

            return position;
        }
    }
}
