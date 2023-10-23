using Cysharp.Threading.Tasks;
using SNEngine.Services;
using UnityEngine;

namespace SNEngine.CharacterSystem.Animations
{
    public class FadeCharacterNode : AsyncCharacterNode
    {
        [Input(connectionType = ConnectionType.Override), Range(0, 1), SerializeField] private float _value;
        public override void Operation(Character character, float duration)
        {
            float value = _value;

            var input = GetInputPort(nameof(_value));

            if (input.Connection != null)
            {
                value = GetDataFromPort<float>(nameof(_value));
            }

            Fade(character, value, duration).Forget();
        }

        private async UniTask Fade (Character character, float value, float duration)
        {
            var serviceCharacters = NovelGame.GetService<CharacterService>();

            await serviceCharacters.FadeCharacter(character, value, duration);

            StopTask();
        }
    }
}
