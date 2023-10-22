﻿using SiphoinUnityHelpers.XNodeExtensions.AsyncNodes;
using SNEngine.CharacterSystem;
using SNEngine.Services;
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
            return _text;
        }

        public void MarkIsEnd ()
        {
            StopTask();
        }


    }
}