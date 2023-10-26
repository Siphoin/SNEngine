namespace SNEngine.DialogSystem
{
    public interface IDialogWindow : IHidden, IShowable, IResetable, IPrinterText, IPrinterTalkingCharacter, ISeterData<IDialogNode>
    {
        void StartOutputDialog();
    }
}
