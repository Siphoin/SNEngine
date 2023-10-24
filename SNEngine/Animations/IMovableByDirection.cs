using Cysharp.Threading.Tasks;
using DG.Tweening;

namespace SNEngine.Animations
{
    public interface IMovableByDirection
    {
        UniTask Move(Direction direction, float time, Ease ease);
    }
}
