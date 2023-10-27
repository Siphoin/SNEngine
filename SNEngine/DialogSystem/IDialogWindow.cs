namespace SNEngine.DialogSystem
{
    public interface IDialogWindow : IHidden, IShowable, IResetable, IPrinterText, IPrinterDialogueText, IPrinterTalkingCharacter, ISeterData<IDialogNode>
    {
    }
}
