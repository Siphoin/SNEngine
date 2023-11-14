using SiphoinUnityHelpers.XNodeExtensions;
using System.Linq;

namespace SNEngine.Extensions
{
    public static class NodeQueueExtensions
    {
        public static bool HasNextDialogueOnExit (this NodeQueue nodeQueue)
        {
            return nodeQueue.ExitNodes.Any(x => x is JumpToDialogueNode);
        }
    }
}
