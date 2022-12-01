using System;

namespace SNEngineLib.Interfaces
{
    public interface ICharacter
    {
        public string Id { get; }

        public event Action<string, string> OnSayoing;

        void Say(string name, string text);
        void Show(string emotion = "normal");
        void Hide();
    }
}
