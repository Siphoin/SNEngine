using SNEngine.Animations;
using SNEngine.Services;

namespace SNEngine.CharacterSystem
{
    public class SetFlipCharacterNode : SetFlipNode<Character>
    {
        protected override void SetFlip(Character target, FlipType flipType)
        {
            var serviceCharacters = NovelGame.GetService<CharacterService>();

            serviceCharacters.SetFlipCharacter(target, flipType);
        }
    }
}
