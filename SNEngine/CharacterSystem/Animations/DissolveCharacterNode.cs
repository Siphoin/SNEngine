using Cysharp.Threading.Tasks;
using DG.Tweening;
using SNEngine.Services;

namespace SNEngine.CharacterSystem.Animations
{
    public class DissolveCharacterNode : AsyncCharacterNode
    {
        
        protected override void Play(Character target, float duration, Ease ease)
        {
            Dissolve(target, duration, ease).Forget();
        }

        private async UniTask Dissolve (Character target, float duration, Ease ease)
        {
            var serviceCharacters = NovelGame.GetService<CharacterService>();

            await serviceCharacters.DissolveCharacter(target, duration, ease);

            StopTask();

        }
    }
}
