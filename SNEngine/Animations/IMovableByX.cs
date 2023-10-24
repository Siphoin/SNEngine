using Cysharp.Threading.Tasks;
using DG.Tweening;

namespace SNEngine.Animations
{
    public interface IMovableByX
    {
        UniTask Move(float x, float time, Ease ease);
    }
}
