using System.Collections;
using System.Collections.Generic;

namespace SNEngineLib.Interfaces
{
    public interface INovelEngine
    {
        ICollection<ILabel> LabelsList { get; }
    }
}
