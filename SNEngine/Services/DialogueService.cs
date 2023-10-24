using SNEngine.DialogSystem;
using SNEngine.Graphs;
using System;
using UnityEngine;

namespace SNEngine.Services
{
    internal class DialogueService : IService
    {
        private IDialogue _currentDialogue;

        private IDialogue _startDialogue;

        public void Initialize()
        {
            _startDialogue = Resources.Load<DialogueGraph>($"Dialogues/{nameof(_startDialogue)}");

            // TODO: jumping to start dialogue with main menu

            JumpToStartDialogue();
            
        }

        public void JumpToStartDialogue()
        {
            JumpToDialogue(_startDialogue);
        }

        public void JumpToDialogue(IDialogue dialogue)
        {
            if (dialogue is null)
            {
                throw new ArgumentNullException("dialogue argument is null");
            }

            if (_currentDialogue != null)
            {
                _currentDialogue.OnEndExecute -= OnEndExecute;

                _currentDialogue.Stop();
            }

            NovelGame.ResetStateServices();

            _currentDialogue = dialogue;

            _currentDialogue.OnEndExecute += OnEndExecute;

            _currentDialogue.Execute();
        }

        private void OnEndExecute()
        {
            _currentDialogue.OnEndExecute -= OnEndExecute;

            NovelGame.ResetStateServices();

            // TODO Return to main menu
        }
    }
}
