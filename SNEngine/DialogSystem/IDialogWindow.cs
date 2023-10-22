namespace SNEngine.DialogSystem
{
    public interface IDialogWindow : IHidden, IShowable, ISeterData<IDialogNode>
    {
        void StartOutputDialog();
    }
}
