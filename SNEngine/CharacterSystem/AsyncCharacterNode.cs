using SiphoinUnityHelpers.XNodeExtensions.AsyncNodes;
using UnityEngine;

namespace SNEngine.CharacterSystem
{
    public abstract class AsyncCharacterNode : AsyncNode
    {
        [SerializeField] private Character _character;

        [Input(connectionType = ConnectionType.Override), SerializeField] private bool _wait;

        [Input(connectionType = ConnectionType.Override), SerializeField, Min(0)] private float _duration;

        public override void Execute()
        {
            bool wait = _wait;

            float duration = _duration;

            if (GetInputPort(nameof(_wait)).Connection != null)
            {
                wait = GetDataFromPort<bool>(nameof(_wait));
            }

            if (GetInputPort(nameof(_duration)).Connection != null)
            {
                duration = GetDataFromPort<float>(nameof(_duration));
            }

            if (wait)
            {
                base.Execute();
            }

            Operation(_character, duration);


        }

        public abstract void Operation (Character character, float duration);
    }
}
