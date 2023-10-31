using Cysharp.Threading.Tasks;
using DG.Tweening;

namespace SNEngine.Animations
{
    public interface ISolidable
    {
        UniTask Solid(float time, AnimationBehaviourType animationBehaviour, Ease ease);

        UniTask Solid(float time, float value, Ease ease);
    }
}
