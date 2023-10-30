namespace SNEngine.Animations
{
    public static class AnimationBehaviourHelper
    {
        public static float GetValue (AnimationBehaviourType type)
        {
            return type == AnimationBehaviourType.In ? 1f : 0f;
        }
    }
}
