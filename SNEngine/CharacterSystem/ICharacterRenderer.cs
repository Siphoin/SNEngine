using SNEngine.Animations;

namespace SNEngine.CharacterSystem
{
    public interface ICharacterRenderer : IShowable, IHidden, IResetable, IMovableByX, IFadeable, IRotateable, IScaleable, IChangeableColor, IFlipable, ISeterData<Character>
    {
        void ShowWithEmotion(string emotionName);
    }
}
