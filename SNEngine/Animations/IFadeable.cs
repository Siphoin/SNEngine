using Cysharp.Threading.Tasks;
using DG.Tweening;

namespace SNEngine.Animations
{
    public interface IFadeable
    {
        UniTask Fade(float value, float time, Ease ease);
    }
}
