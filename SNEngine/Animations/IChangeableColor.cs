using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace SNEngine.Animations
{
    public interface IChangeableColor
    {
        UniTask ChangeColor(Color color, float time, Ease ease);
    }
}
