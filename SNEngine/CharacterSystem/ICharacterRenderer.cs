using Cysharp.Threading.Tasks;
using DG.Tweening;
using SNEngine.Animations;

namespace SNEngine.CharacterSystem
{
    public interface ICharacterRenderer : IShowable, IHidden, IResetable, IMovableByX, IFadeable, IRotateable, IScaleable, IChangeableColor, IDissolveable, IBlackAndWhiteSupport, ICeliable, ISolidable, IIlluminatiionable, IFlipable, ISeterData<Character>
    {
        void ShowWithEmotion(string emotionName);

        UniTask Move(CharacterDirection direction, float time, Ease ease);
    }
}
