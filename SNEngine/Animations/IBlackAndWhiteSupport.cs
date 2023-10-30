using Cysharp.Threading.Tasks;
using DG.Tweening;

namespace SNEngine.Animations
{
    public interface IBlackAndWhiteSupport
    {
        UniTask ToBlackAndWhite(float time, AnimationBehaviourType animationBehaviour, Ease ease);

        UniTask ToBlackAndWhite(float time, float value, Ease ease);
    }
}
