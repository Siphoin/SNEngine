using Cysharp.Threading.Tasks;
using DG.Tweening;

namespace SNEngine.Animations
{
    public interface IIlluminatiionable
    {
        UniTask Illuminate(float time, AnimationBehaviourType animationBehaviour, Ease ease);

        UniTask Illuminate(float time, float value, Ease ease);
    }
}
