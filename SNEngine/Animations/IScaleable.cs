using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace SNEngine.Animations
{
    public interface IScaleable
    {
        UniTask Scale(Vector3 scale, float time, Ease ease);
    }
}
