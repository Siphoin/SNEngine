using Cysharp.Threading.Tasks;
using DG.Tweening;
using System.Threading.Tasks;
using UnityEngine;

namespace SNEngine.CharacterSystem
{
    public interface ICharacterRenderer : IShowable, IHidden, IResetable, ISeterData<Character>
    {
        void ShowWithEmotion(string emotionName);

        void SetFlipX(bool flipX);

        #region Animations
        UniTask Move(float x, float time);

        UniTask Fade(float value, float time);

        UniTask Scale(Vector3 scale, float time);

        UniTask Rotate(Vector3 angle, float time, RotateMode rotateMode);
        #endregion
    }
}
