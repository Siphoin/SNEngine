using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace SNEngine.Animations
{
    public interface IDissolveable
    {
        UniTask Dissolve(float time, AnimationBehaviourType animationBehaviour, Ease ease, Texture2D texture = null);
    }
}
