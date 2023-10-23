using Cysharp.Threading.Tasks;
using SNEngine.Services;
using UnityEngine;

namespace SNEngine.CharacterSystem.Animations
{
    public class MoveCharacterNode : AsyncCharacterNode
    {

        [Input(connectionType = ConnectionType.Override), SerializeField] private float _x;

        public override void Operation(Character character, float duration)
        {
            float x = _x;

          if (GetInputPort(nameof(_x)).Connection != null)
            {
                x = GetDataFromPort<float>(nameof(_x));
            }

          Move(x, duration, character).Forget();
        }

        private async UniTask Move (float x, float duration, Character character)
        {
            var serviceCharacters = NovelGame.GetService<CharacterService>();

            await serviceCharacters.MoveCharacter(character, x, duration);

            StopTask();
        }

    }
}
