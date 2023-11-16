namespace SNEngine.InputFormSystem
{
    public interface IInputForm : IShowable, IHidden, ISubmitter, IResetable
    {
        string Label { get; set; }

        InputFormType Type { get; }
        bool IsTrimming { get; set; }
    }
}
