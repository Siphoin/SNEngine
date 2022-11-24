namespace SNEngineLib.Interfaces
{
    public interface IPanelDialog
    {
        bool IsShow { get; }

        void SetShowState(bool state);
    }
}
