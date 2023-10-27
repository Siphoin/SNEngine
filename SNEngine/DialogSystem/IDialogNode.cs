using SNEngine.CharacterSystem;

namespace SNEngine.DialogSystem
{
    public interface IDialogNode : IPrinterNode
    {
        Character Character { get; }
    }
}
