using SNEngine.Graphs;
using SNEngine.Services;
using UnityEngine;

namespace SNEngine.Assets.SNEngine
{
    public class DialogueStarter : MonoBehaviour
    {
        [SerializeField] private DialogueGraph _dialogue;

        private void Start()
        {
            _dialogue.Execute();

            _dialogue.OnEndExecute += OnEndExecute;
        }

        private void OnEndExecute()
        {
            _dialogue.OnEndExecute -= OnEndExecute;

            NovelGame.ResetStateServices();
        }
    }
}