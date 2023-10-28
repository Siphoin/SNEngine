using Cysharp.Threading.Tasks;
using DG.Tweening;
using SNEngine.Animations;
using SNEngine.Services;
using UnityEngine;

namespace SNEngine.CharacterSystem.Animations
{
    public class DissolveCharacterNode : AsyncCharacterNode
    {

        [SerializeField] private AnimationBehaviourType _type;
        
        protected override void Play(Character target, float duration, Ease ease)
        {
            Dissolve(target, duration, ease).Forget();
        }

        private async UniTask Dissolve (Character target, float duration, Ease ease)
        {
            var serviceCharacters = NovelGame.GetService<CharacterService>();

            await serviceCharacters.DissolveCharacter(target, _type, duration, ease);

            StopTask();

        }
    }
}
