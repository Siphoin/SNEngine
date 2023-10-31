using SNEngine.Animations;

namespace SNEngine.CharacterSystem
{
    public interface ICharacterRenderer : IShowable, IHidden, IResetable, IMovableByX, IFadeable, IRotateable, IScaleable, IChangeableColor, IDissolveable, IBlackAndWhiteSupport, ICeliable, ISolidable, IIlluminatiionable, IFlipable, ISeterData<Character>
    {
        void ShowWithEmotion(string emotionName);
    }
}
