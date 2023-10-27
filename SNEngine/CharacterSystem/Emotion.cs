using SNEngine.Debugging;
using System;
using UnityEngine;

namespace SNEngine.CharacterSystem
{
    [Serializable]
    public class Emotion
    {
        [SerializeField] private string _name;

        [SerializeField] private Sprite _sprite;

        public string Name => _name;
        public Sprite Sprite { get
            {
                if (_sprite is null)
                {
                    NovelGameDebug.LogError($"Sprite of emotion {_name} is null!");
                }

                return _sprite;
            } }

        public Emotion ()
        {

        }

        public Emotion (string name)
        {
            _name = name;
        }
    }
}
