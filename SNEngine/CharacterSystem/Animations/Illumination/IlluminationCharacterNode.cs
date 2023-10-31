using Cysharp.Threading.Tasks;
using DG.Tweening;
using SNEngine.Services;
using System;
using UnityEngine;

namespace SNEngine.CharacterSystem.Animations.Illumination
{
    public class IlluminationCharacterNode : AsyncCharacterNode
    {
        [Input(connectionType = ConnectionType.Override), Range(0, 1), SerializeField] private float _value;

        protected override void Play(Character target, float duration, Ease ease)
        {
            float value = _value;

            var input = GetInputPort(nameof(_value));

            if (input.Connection != null)
            {
                value = GetDataFromPort<float>(nameof(_value));
            }
            Illuminate(target, value, duration, ease).Forget();
        }

        private async UniTask Illuminate(Character character, float value, float duration, Ease ease)
        {
            var serviceCharacters = NovelGame.GetService<CharacterService>();

            await serviceCharacters.IlluminateCharacter(character, value, duration, ease);

            StopTask();
        }
    }
}
