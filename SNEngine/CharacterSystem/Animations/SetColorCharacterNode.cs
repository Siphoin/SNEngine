using Cysharp.Threading.Tasks;
using DG.Tweening;
using SNEngine.Animations;
using SNEngine.Services;
using UnityEngine;

namespace SNEngine.CharacterSystem.Animations
{
    public class SetColorCharacterNode : ChangeColorNode<Character>
    {
        protected override void ChangeColor(Character target, Color color, float duration, Ease ease)
        {
            SetColor(target, color, duration, ease).Forget();
        }

        private async UniTask SetColor (Character target, Color color, float duration, Ease ease)
        {
            var serviceCharacters = NovelGame.GetService<CharacterService>();

            await serviceCharacters.SetColorCharacter(target, color, duration, ease);
            StopTask();
        }
    }
}
