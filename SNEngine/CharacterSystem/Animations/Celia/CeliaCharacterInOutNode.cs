using Cysharp.Threading.Tasks;
using DG.Tweening;
using SNEngine.Animations;
using SNEngine.Services;
using UnityEngine;

namespace SNEngine.CharacterSystem.Animations.Celia
{
    public class CeliaCharacterInOutNode : AnimationInOutNode<Character>
    {
        protected override void Play(Character target, float duration, AnimationBehaviourType type, Ease ease)
        {
            Celia(target, type, duration, ease).Forget();
        }

        private async UniTask Celia(Character character, AnimationBehaviourType animationBehaviour, float duration, Ease ease)
        {
            var serviceCharacters = NovelGame.GetService<CharacterService>();

            await serviceCharacters.CeliaCharacter(character, animationBehaviour, duration, ease);

            StopTask();
        }
    }
}
