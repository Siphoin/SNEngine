using Cysharp.Threading.Tasks;
using SNEngine.Services;
using UnityEngine;

namespace SNEngine.CharacterSystem.Animations
{
    public class ScaleCharacterNode : AsyncCharacterNode
    {
        [Input(connectionType = ConnectionType.Override), SerializeField] private Vector3 _scale = Vector3.one;
        public override void Operation(Character character, float duration)
        {
            Vector3 scale = _scale;

            var input = GetInputPort(nameof(_scale));

            if (input.Connection != null)
            {
                scale = GetDataFromPort<Vector3>(nameof(_scale));
            }

            Scale(scale, duration, character).Forget();
        }

        private async UniTask Scale(Vector3 scale, float duration, Character character)
        {
            var serviceCharacters = NovelGame.GetService<CharacterService>();

            await serviceCharacters.ScaleCharacter(character, scale, duration);

            StopTask();
        }
    }
}
