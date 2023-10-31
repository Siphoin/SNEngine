using Cysharp.Threading.Tasks;
using SNEngine.Debugging;
using SNEngine.DialogSystem;
using SNEngine.Graphs;
using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace SNEngine.Services
{
    internal class DialogueService : IService
    {
        private IDialogue _currentDialogue;

        private IDialogue _startDialogue;

        private IOldRenderDialogue _oldRenderDialogueService;

        private MonoBehaviour _frameDetector;

        public void Initialize()
        {
            _oldRenderDialogueService = NovelGame.GetService<RenderOldDialogueService>();

            _startDialogue = Resources.Load<DialogueGraph>($"Dialogues/{nameof(_startDialogue)}");

            var frameDetector = Resources.Load<Dialog_FrameDetector>("System/Dialog_FrameDetector");

            var prefabFrameDetector = Object.Instantiate(frameDetector);

            prefabFrameDetector.name = frameDetector.name;

            Object.DontDestroyOnLoad(prefabFrameDetector);

            _frameDetector = prefabFrameDetector;

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
                NovelGameDebug.LogError("dialogue argument is null. Check your graph");
            }

            if (_currentDialogue != null)
            {
                _currentDialogue.OnEndExecute -= OnEndExecute;

                _currentDialogue.Stop();
            }

            _currentDialogue = dialogue;

            _currentDialogue.OnEndExecute += OnEndExecute;

            NovelGameDebug.Log($"Jump To Dialogue: {_currentDialogue.Name}");

            _currentDialogue.Execute();
        }

        private void OnEndExecute()
        {
            _currentDialogue.OnEndExecute -= OnEndExecute;

            ClearScreen().Forget();

            // TODO Return to main menu
        }

        private async UniTask ClearScreen()
        {
            _oldRenderDialogueService.UpdateRender();

            for (int i = 0; i < 2; i++)
            {
                await UniTask.WaitForEndOfFrame(_frameDetector);
            }

           

            NovelGame.ResetStateServices();

            _oldRenderDialogueService.Clear();
        }
    }
}
