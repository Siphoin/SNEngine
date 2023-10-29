using SiphoinUnityHelpers.XNodeExtensions;
using SNEngine.Graphs;
using SNEngine.Services;
using UnityEngine;

namespace SNEngine
{
    [NodeWidth(260)]
    [NodeTint("#3b3b3b")]
    public class JumpToDialogueNode : ExitNode
    {
        [SerializeField] private DialogueGraph _dialogue;

        public override void Execute()
        {

            base.Execute();

            var dialogueService = NovelGame.GetService<DialogueService>();

            dialogueService.JumpToDialogue(_dialogue);
        }
    }
}
