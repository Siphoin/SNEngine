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
        public Sprite Sprite => _sprite;

        public Emotion ()
        {

        }

        public Emotion (string name)
        {
            _name = name;
        }
    }
}
