using SiphoinUnityHelpers.XNodeExtensions;
using SiphoinUnityHelpers.XNodeExtensions.AsyncNodes;
using SNEngine.CharacterSystem;
using SNEngine.Repositories;
using SNEngine.Services;
using System.Collections.Generic;
using UnityEngine;

namespace SNEngine.DialogSystem
{
    public class DialogNode : AsyncNode, IDialogNode
    {
        [SerializeField] private Character _character;

        [SerializeField, TextArea] private string _text;

        public Character Character => _character;

        public override void Execute()
        {
            base.Execute();

            var serviceDialogs = NovelGame.GetService<DialogueService>();

            serviceDialogs.ShowDialog(this);
        }

        public string GetText()
        {
            
            var parentGraph = graph as BaseGraph;

            var varitables = parentGraph.Varitables;

            var characters = NovelGame.GetRepository<CharacterRepository>().Characters;

            return TextParser.ParseWithProperties(_text, varitables, characters);
        }

        public int GetLengthText ()
        {
            return _text.Length;
        }

        public void MarkIsEnd ()
        {
            StopTask();

        }


    }
}