using SNEngine.Animations;
using UnityEngine;

namespace SNEngine.Extensions
{
    internal static class Vector3Extensions
    {

        public static Vector3 GetScreenEdge(this Transform transform, Direction direction)
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