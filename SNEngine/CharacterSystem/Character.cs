using SiphoinUnityHelpers.XNodeExtensions.Extensions;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace SNEngine.CharacterSystem
{
    [CreateAssetMenu]
    public class Character : ScriptableObjectIdentity
    {
        private const string DEFAULT_EMOTION_NAME = "Default";

        [Space]

        [SerializeField] private string _name;

        [Space]

        [SerializeField, TextArea] private string _description;

        [Space]

        [SerializeField] private Color _colorName = Color.white;

        [Space]

        [SerializeField] private Emotion[] _emotions = new Emotion[]
        {
            new Emotion(DEFAULT_EMOTION_NAME)
        };


        public string Description => _description;
        public Color ColorName => _colorName;

        public IEnumerable<Emotion> Emotions => _emotions;

        public string GetName () => _name;

        public Emotion GetEmotion (string name = DEFAULT_EMOTION_NAME)
        {
            return _emotions.SingleOrDefault(x  => x.Name == name);
        }

        public string GetNameWithColor ()
        {
            return _colorName.ToColorTag(GetName());
        }
    }
}