using Cysharp.Threading.Tasks;
using DG.Tweening;
using SNEngine.Services;
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace SNEngine.CharacterSystem.Animations
{
    public class RotateCharacterNode : AsyncCharacterNode
    {
        [Input(connectionType = ConnectionType.Override), SerializeField] private Vector3 _angle;

        [SerializeField] private RotateMode _rotateMode;

        protected override void Play(Character target, float duration, Ease ease)
        {
            Vector3 angle = _angle;

            var input = GetInputPort(nameof(_angle));

            if (input.Connection != null)
            {
                _angle = GetDataFromPort<Vector3>(nameof(_angle));
            }

            Rotate(angle, duration, target, ease).Forget();
        }

        private async UniTask Rotate(Vector3 angle, float duration, Character character, Ease ease)
        {
            var serviceCharacters = NovelGame.GetService<CharacterService>();

            await serviceCharacters.RotateCharacter(character, angle, duration, ease, _rotateMode);

            StopTask();
        }
    }
}
