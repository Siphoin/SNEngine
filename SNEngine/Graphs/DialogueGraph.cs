using SiphoinUnityHelpers.XNodeExtensions;
using SNEngine.DialogSystem;
using UnityEngine;

namespace SNEngine.Graphs
{
    [CreateAssetMenu(menuName = "SNEngine/New Dialogue Graph")]
    public class DialogueGraph : BaseGraph, IDialogue
    {
        public object Name => name;
    }
}
