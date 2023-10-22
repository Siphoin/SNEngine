using SNEngine.CharacterSystem;

namespace SNEngine.DialogSystem
{
    public interface IDialogNode
    {
        Character Character { get; }

        void MarkIsEnd();

        string GetText();

        int GetLengthText();
    }
}
