using SNEngine.CharacterSystem;
using SNEngine.Repositories;
using System.Collections.Generic;
using UnityEngine;
using System;
using Object = UnityEngine.Object;
using Cysharp.Threading.Tasks;
using DG.Tweening;

namespace SNEngine.Services
{
    public class CharacterService : IService, IResetable
    {
        private Dictionary<string, ICharacterRenderer> _characters;
        
        public void Initialize()
        {
            var characterObject = Resources.Load<CharacterRenderer>("Render/Character");

            _characters = new Dictionary<string, ICharacterRenderer>();

            var characters = NovelGame.GetRepository<CharacterRepository>().Characters;

            Transform container = new GameObject($"{nameof(Character)}s").transform;

            Object.DontDestroyOnLoad(container);

            foreach (var character in characters)
            {
                var newCharacter = Object.Instantiate(characterObject, container, false);

                newCharacter.Hide();

                newCharacter.SetData(character.Value);

                newCharacter.name = character.Value.GetName();

                _characters.Add(character.Value.name, newCharacter);
            }
        }

        public void ShowCharacter (Character character, string emotionName = "Default")
        {
            if (character is null)
            {
                throw new NullReferenceException("character argument is null/ Check your node Graph");
            }

            var characterRender = FindByName(character.name);

            characterRender.ShowWithEmotion(emotionName);
        }

        public void HideCharacter(Character character)
        {
            if (character is null)
            {
                throw new NullReferenceException("character argument is null. Check your node Graph");
            }

            var characterRender = FindByName(character.name);

            characterRender.Hide();
        }

        public void SetFlipXCharacter (Character character, bool flipX)
        {
            if (character is null)
            {
                throw new NullReferenceException("character argument is null. Check your node Graph");
            }

            var characterRender = FindByName(character.name);

            characterRender.SetFlipX(flipX);
        }

        #region Animations
        public async UniTask MoveCharacter(Character character, float x, float time)
        {
            if (character is null)
            {
                throw new NullReferenceException("character argument is null. Check your node Graph");
            }

            var characterRender = FindByName(character.name);

            await characterRender.Move(x, time);
        }

        public async UniTask FadeCharacter(Character character, float value, float time)
        {
            if (character is null)
            {
                throw new NullReferenceException("character argument is null. Check your node Graph");
            }

            var characterRender = FindByName(character.name);

            await characterRender.Fade(value, time);
        }

        public async UniTask ScaleCharacter(Character character, Vector3 value, float time)
        {
            if (character is null)
            {
                throw new NullReferenceException("character argument is null. Check your node Graph");
            }

            var characterRender = FindByName(character.name);

            await characterRender.Scale(value, time);
        }

        public async UniTask RotateCharacter(Character character, Vector3 value, float time, RotateMode rotateMode = RotateMode.Fast)
        {
            if (character is null)
            {
                throw new NullReferenceException("character argument is null. Check your node Graph");
            }

            var characterRender = FindByName(character.name);

            await characterRender.Rotate(value, time, rotateMode);
        }
        #endregion

        private ICharacterRenderer FindByName (string name)
        {
            if (_characters.ContainsKey(name))
            {
                return _characters[name];
            }

            throw new NullReferenceException($"character with name {name} not founds on db characters");
        }

        public void ResetState()
        {
            foreach (var character in _characters.Values)
            {
                character.ResetState();
            }
        }
    }
}
