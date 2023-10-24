using Cysharp.Threading.Tasks;
using DG.Tweening;
using SNEngine.Services;
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace SNEngine.CharacterSystem.Animations
{
    public class MoveCharacterNode : AsyncCharacterNode
    {


        [Input(connectionType = ConnectionType.Override), SerializeField] private float _x;

        protected override void Play(Character target, float duration, Ease ease)
        {
            float x = _x;

            if (GetInputPort(nameof(_x)).Connection != null)
            {
                x = GetDataFromPort<float>(nameof(_x));
            }

            Move(x, duration, target, ease).Forget();
        }

        private async UniTask Move (float x, float duration, Character character, Ease ease)
        {
            var serviceCharacters = NovelGame.GetService<CharacterService>();

            Debug.Log(223);

            await serviceCharacters.MoveCharacter(character, x, duration, ease);

            StopTask();
        }

    }
}
