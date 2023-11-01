using Cysharp.Threading.Tasks;
using DG.Tweening;
using SNEngine.Animations;
using SNEngine.Services;
using UnityEngine;

namespace SNEngine.CharacterSystem
{
    public class MoveCharacterByDirectionScreenNode : AsyncCharacterNode
    {
        [SerializeField] private CharacterDirection _direction;
        protected override void Play(Character target, float duration, Ease ease)
        {
            Move(duration, target, ease).Forget();
        }

        private async UniTask Move(float duration, Character character, Ease ease)
        {
            var serviceCharacters = NovelGame.GetService<CharacterService>();

            await serviceCharacters.MoveCharacter(character, _direction, duration, ease);

            StopTask();
        }
    }
}
