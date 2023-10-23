using SiphoinUnityHelpers.XNodeExtensions;
using UnityEngine;

namespace SNEngine.CharacterSystem
{
    public abstract class CharacterNode : BaseNodeInteraction
    {
        [SerializeField] private Character _character;

        public Character Character => _character;

        public override void Execute()
        {
            Operation(_character);
        }

        public abstract void Operation(Character character);
    }
}
