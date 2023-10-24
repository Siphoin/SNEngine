using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Numerics;

namespace SNEngine.Animations
{
    public interface IMovableByVector
    {
        UniTask Move(Vector2 position, float time, Ease ease);
    }
}
