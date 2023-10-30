using Cysharp.Threading.Tasks;
using DG.Tweening;
using SNEngine.Animations;
using SNEngine.Services;
using UnityEngine;

namespace SNEngine.CharacterSystem.Animations.Fade
{
    public class FadeCharacterInOutNode : AnimationInOutNode<Character>
    {
        [Input(connectionType = ConnectionType.Override), Range(0, 1), SerializeField] private float _value;

        protected override void Play(Character target, float duration, AnimationBehaviourType type, Ease ease)
        {
            float value = _value;

            var input = GetInputPort(nameof(_value));

            if (input.Connection != null)
            {
                value = GetDataFromPort<float>(nameof(_value));
            }

            Fade(target, type, value, ease).Forget();
        }

        private async UniTask Fade(Character character, AnimationBehaviourType animationBehaviour, float duration, Ease ease)
        {
            var serviceCharacters = NovelGame.GetService<CharacterService>();

            await serviceCharacters.FadeCharacter(character, animationBehaviour, duration, ease);

            StopTask();
        }
    }
}
