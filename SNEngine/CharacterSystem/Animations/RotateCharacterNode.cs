using Cysharp.Threading.Tasks;
using DG.Tweening;
using SNEngine.Services;
using UnityEngine;

namespace SNEngine.CharacterSystem.Animations
{
    public class RotateCharacterNode : AsyncCharacterNode
    {
        [Input(connectionType = ConnectionType.Override), SerializeField] private Vector3 _angle;

        [SerializeField] private RotateMode _rotateMode;
        public override void Operation(Character character, float duration)
        {
            Vector3 angle = _angle;

            var input = GetInputPort(nameof(_angle));

            if (input.Connection != null)
            {
                _angle = GetDataFromPort<Vector3>(nameof(_angle));
            }

            Rotate(angle, duration, character).Forget();
        }

        private async UniTask Rotate(Vector3 angle, float duration, Character character)
        {
            var serviceCharacters = NovelGame.GetService<CharacterService>();

            await serviceCharacters.RotateCharacter(character, angle, duration, _rotateMode);

            StopTask();
        }
    }
}
