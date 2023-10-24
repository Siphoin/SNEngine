using SiphoinUnityHelpers.XNodeExtensions;
using SNEngine.Graphs;
using SNEngine.Services;
using UnityEngine;

namespace SNEngine
{
    [NodeWidth(260)]
    public class JumpToDialogueNode : BaseNodeInteraction
    {
        [SerializeField] private DialogueGraph _dialogue;

        public override void Execute()
        {
            var dialogueService = NovelGame.GetService<DialogueService>();

            dialogueService.JumpToDialogue(_dialogue);
        }
    }
}
