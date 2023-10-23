using SNEngine.Services;

namespace SNEngine.CharacterSystem
{
    public class HideCharacterNode : CharacterNode
    {
        public override void Operation(Character character)
        {
            var serviceCharacters = NovelGame.GetService<CharacterService>();

            serviceCharacters.HideCharacter(character);
        }
    }
}
