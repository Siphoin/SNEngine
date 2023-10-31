using Cysharp.Threading.Tasks;
using DG.Tweening;
using SNEngine.Animations;
using SNEngine.Services;

namespace SNEngine.CharacterSystem.Animations.Illumination
{
    public class IlluminationCharacterInOutNode : AnimationInOutNode<Character>
    {
        protected override void Play(Character target, float duration, AnimationBehaviourType type, Ease ease)
        {
            Illuminate(target, type, duration, ease).Forget();
        }

        private async UniTask Illuminate(Character character, AnimationBehaviourType animationBehaviour, float duration, Ease ease)
        {
            var serviceCharacters = NovelGame.GetService<CharacterService>();

            await serviceCharacters.BlackAndWhiteCharacter(character, animationBehaviour, duration, ease);

            StopTask();
        }
    }
}
