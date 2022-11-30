using System;
using System.Collections.Generic;

namespace SNEngineLib.Interfaces
{
    public interface INovelEngine
    {
        public int CountLabels { get; }

        ILabel CurrentLabel { get; }

        IContentPipeline ContentPipeline { get; }

        event Action<ILabel> LabelChanged;

        ICollection<ILabel> LabelsList { get; }

        void JumpToLabel(ILabel label);

        void JumpToLabel(string labelName);

        void AddLabel(ILabel label);

        bool CharacterExits(string id);
    }
}
