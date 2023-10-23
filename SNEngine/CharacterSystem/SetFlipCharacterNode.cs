using SNEngine.Services;
using UnityEngine;

namespace SNEngine.CharacterSystem
{
    public class SetFlipCharacterNode : CharacterNode
    {
        [Input(connectionType = ConnectionType.Override), SerializeField] private bool _flip;
        public override void Operation(Character character)
        {
            bool flip = _flip;

            if (GetInputPort(nameof(_flip)).Connection != null)
            {
                flip = GetDataFromPort<bool>(nameof(_flip));
            }

            var serviceCharacters = NovelGame.GetService<CharacterService>();

            serviceCharacters.SetFlipXCharacter(character, flip);
        }
    }
}
