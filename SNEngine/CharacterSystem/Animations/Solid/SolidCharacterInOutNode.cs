using Cysharp.Threading.Tasks;
using DG.Tweening;
using SNEngine.Animations;
using SNEngine.Services;

namespace SNEngine.CharacterSystem.Animations.Solid
{
    public class SolidCharacterInOutNode : AnimationInOutNode<Character>
    {
        protected override void Play(Character target, float duration, AnimationBehaviourType type, Ease ease)
        {
            Solid(target, type, duration, ease).Forget();
        }

        private async UniTask Solid(Character character, AnimationBehaviourType animationBehaviour, float duration, Ease ease)
        {
            var serviceCharacters = NovelGame.GetService<CharacterService>();

            await serviceCharacters.SolidCharacter(character, animationBehaviour, duration, ease);

            StopTask();
        }
    }
}
