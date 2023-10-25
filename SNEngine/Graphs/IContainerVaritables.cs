using SiphoinUnityHelpers.XNodeExtensions;
using System.Collections.Generic;

namespace SNEngine.Graphs
{
    public interface IContainerVaritables
    {
        IDictionary<string, VaritableNode> GlobalVaritables { get; }
    }
}
