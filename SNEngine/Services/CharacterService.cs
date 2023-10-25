using SNEngine.CharacterSystem;
using SNEngine.Repositories;
using System.Collections.Generic;
using UnityEngine;
using System;
using Object = UnityEngine.Object;
using Cysharp.Threading.Tasks;
using DG.Tweening;
using SNEngine.Animations;
using SNEngine.Debugging;

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
            if (LogErrorNullReferenceCharacter(character))
            {
                return;
            }

            var characterRender = FindByName(character.name);

            characterRender.ShowWithEmotion(emotionName);
        }

        private  bool LogErrorNullReferenceCharacter(Character character)
        {
            if (character is null)
            {
                NovelGameDebug.LogError("character argument is null. Check your node Graph");

                return true;
            }

            return false;
           
        }

        public void HideCharacter(Character character)
        {
            if (LogErrorNullReferenceCharacter(character))
            {
                return;
            }

            var characterRender = FindByName(character.name);

            characterRender.Hide();
        }

        public void SetFlipCharacter (Character character, FlipType flipType)
        {
            if (LogErrorNullReferenceCharacter(character))
            {
                return;
            }

            var characterRender = FindByName(character.name);

            characterRender.SetFlip(flipType);
        }

        #region Animations
        public async UniTask MoveCharacter(Character character, float x, float time, Ease ease)
        {
            if (character is null)
            {
                throw new NullReferenceException("character argument is null. Check your node Graph");
            }

            var characterRender = FindByName(character.name);

            await characterRender.Move(x, time, ease);
        }

        public async UniTask FadeCharacter(Character character, float value, float time, Ease ease)
        {
            if (character is null)
            {
                throw new NullReferenceException("character argument is null. Check your node Graph");
            }

            var characterRender = FindByName(character.name);

            await characterRender.Fade(value, time, ease);
        }

        public async UniTask ScaleCharacter(Character character, Vector3 value, float time, Ease ease)
        {
            if (character is null)
            {
                throw new NullReferenceException("character argument is null. Check your node Graph");
            }

            var characterRender = FindByName(character.name);

            await characterRender.Scale(value, time, ease);
        }

        public async UniTask RotateCharacter(Character character, Vector3 value, float time, Ease ease, RotateMode rotateMode = RotateMode.Fast)
        {
            if (character is null)
            {
                throw new NullReferenceException("character argument is null. Check your node Graph");
            }

            var characterRender = FindByName(character.name);

            await characterRender.Rotate(value, time, ease, rotateMode);
        }

        public async UniTask SetColorCharacter(Character character, Color value, float time, Ease ease)
        {
            if (character is null)
            {
                throw new NullReferenceException("character argument is null. Check your node Graph");
            }

            var characterRender = FindByName(character.name);

            await characterRender.ChangeColor(value, time, ease);
        }
        #endregion

        private ICharacterRenderer FindByName (string name)
        {
            if (_characters.ContainsKey(name))
            {
                return _characters[name];
            }

            NovelGameDebug.LogError($"character with name {name} not founds on db characters");

            return null;
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
