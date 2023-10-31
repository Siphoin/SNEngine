using Cysharp.Threading.Tasks;
using DG.Tweening;

namespace SNEngine.Animations
{
    public  interface ICeliable
    {
        UniTask Celia(float time, AnimationBehaviourType animationBehaviour, Ease ease);

        UniTask Celia(float time, float value, Ease ease);
    }
}
