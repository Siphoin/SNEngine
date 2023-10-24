using UnityEngine;

namespace SNEngine.Extensions
{
    public static class MathfExtensions
    {
        public static float ClampTime(float time)
        {
            return Mathf.Clamp(time, 0, float.MaxValue);
        }
    }
}
