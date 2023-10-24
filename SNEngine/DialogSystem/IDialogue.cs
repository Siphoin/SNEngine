using System;

namespace SNEngine.DialogSystem
{
    public interface IDialogue
    {
        event Action OnEndExecute;

        void Execute();

        void Pause();

        void Stop();
    }
}
