using SNEngine.Attributes;
using SNEngine.Services;
using UnityEngine;

namespace SNEngine.CharacterSystem
{
    public class ShowCharacterNode : CharacterNode
    {
        [SerializeField, EmotionField] private string _emotion = "Default";
        public override void Operation(Character character)
        {
            var serviceCharacters = NovelGame.GetService<CharacterService>();

            serviceCharacters.ShowCharacter(character, _emotion);

           
        }
    }
}
