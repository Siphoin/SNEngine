using SiphoinUnityHelpers.XNodeExtensions;
using SiphoinUnityHelpers.XNodeExtensions.AsyncNodes;
using SNEngine.CharacterSystem;
using SNEngine.Repositories;
using SNEngine.Services;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static UnityEditor.Progress;

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

            string text = _text;

            foreach (KeyValuePair<string, VaritableNode> pair in varitables)
            {
                string key = "[Property=" + pair.Key + "]";

                if (text.Contains(key))
                {
                    text = text.Replace(key, pair.Value.GetCurrentValue().ToString());
                }
            }

            foreach(KeyValuePair<string, Character> pair in characters)
            {
                string key = "[Character=" + pair.Key + "]";

                if (text.Contains(key))
                {
                    text = text.Replace(key, pair.Value.GetName());
                }
            }

            return text;
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