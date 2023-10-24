using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace SNEngine.Animations
{
    public interface IRotateable
    {
        UniTask Rotate(Vector3 angle, float time, Ease ease, RotateMode rotateMode);
    }
}
