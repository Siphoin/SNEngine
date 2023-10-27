using SNEngine.DialogSystem;

namespace SNEngine.DialogOnScreenSystem
{
    public interface IDialogOnScreenWindow : IPrinterText, IPrinterDialogueText, IShowable, IHidden, ISeterData<IDialogOnScreenNode>
    {
    }
}
