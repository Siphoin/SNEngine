using Cysharp.Threading.Tasks;
using DG.Tweening;
using SNEngine.Animations;
using SNEngine.Services;
using UnityEngine;

namespace SNEngine.CharacterSystem.Animations.Dissolve
{
    public class DissolveCharacterNode : DissolveNode<Character>
    {

        protected override void Play(Character target, float duration, AnimationBehaviourType type, Ease ease, Texture2D texture)
        {
            Dissolve(target, duration, type, ease, texture).Forget();
        }

        private async UniTask Dissolve (Character target, float duration, AnimationBehaviourType type, Ease ease, Texture2D texture)
        {
            var serviceCharacters = NovelGame.GetService<CharacterService>();

            await serviceCharacters.DissolveCharacter(target, type, duration, ease, texture);

            StopTask();

        }
    }
}
