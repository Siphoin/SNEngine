using System;

namespace SNEngine.DialogSystem
{
    public interface IDialogue
    {
        object Name { get; }

        event Action OnEndExecute;

        void Execute();

        void Pause();

        void Stop();
    }
}
