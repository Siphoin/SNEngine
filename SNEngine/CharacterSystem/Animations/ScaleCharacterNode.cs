using Cysharp.Threading.Tasks;
using DG.Tweening;
using SNEngine.Services;
using UnityEngine;

namespace SNEngine.CharacterSystem.Animations
{
    public class ScaleCharacterNode : AsyncCharacterNode
    {
        [Input(connectionType = ConnectionType.Override), SerializeField] private Vector3 _scale = Vector3.one;


        protected override void Play(Character target, float duration, Ease ease)
        {
            Vector3 scale = _scale;

            var input = GetInputPort(nameof(_scale));

            if (input.Connection != null)
            {
                scale = GetDataFromPort<Vector3>(nameof(_scale));
            }

            Scale(scale, duration, target, ease).Forget();
        }

        private async UniTask Scale(Vector3 scale, float duration, Character character, Ease ease)
        {
            var serviceCharacters = NovelGame.GetService<CharacterService>();

            await serviceCharacters.ScaleCharacter(character, scale, duration, ease);

            StopTask();
        }
    }
}
