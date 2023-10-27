using SiphoinUnityHelpers.XNodeExtensions;
using SiphoinUnityHelpers.XNodeExtensions.AsyncNodes;
using SNEngine.Animations;
using SNEngine.Attributes;
using UnityEngine;

namespace SNEngine
{
    public abstract class PrinterTextNode : AsyncNode, IPrinterNode
    {
        [SerializeField, TextArea(10, 100)] private string _text = "Some Text";

        public override void Execute()
        {
            base.Execute();
        }

        public string GetText()
        {
            return TextParser.ParseWithProperties(_text, graph as BaseGraph);
        }

        public void MarkIsEnd()
        {
            StopTask();
        }
    }
}
