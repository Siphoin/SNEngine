namespace SNEngine.DialogSystem
{
    public interface IDialogWindow : IHidden, IShowable, IResetable, ISeterData<IDialogNode>
    {
        void StartOutputDialog();
    }
}
