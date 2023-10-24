using Cysharp.Threading.Tasks;
using DG.Tweening;

namespace SNEngine.Animations
{
    public interface IMovable
    {
        UniTask Move(float x, float time, Ease ease);
    }
}
