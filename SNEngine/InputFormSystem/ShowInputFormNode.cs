using SiphoinUnityHelpers.XNodeExtensions.AsyncNodes;
using SNEngine.Services;
using UnityEngine;
using XNode;

namespace SNEngine.InputFormSystem
{
    public class ShowInputFormNode : AsyncNode
    {
        [SerializeField] private string _label = "Input Value";

        [Space]

        [Input(connectionType = ConnectionType.Override), SerializeField] private bool _trimming = false;

        private InputFormType _type;

        [Space]

        [Output(ShowBackingValue.Never), SerializeField] private string _output;

        private InputFormService _service;

        public override void Execute()
        {
            base.Execute();

            bool isTrimming = _trimming;

            var input = GetInputPort(nameof(_trimming));

            if (input.Connection != null)
            {
                isTrimming = GetDataFromPort<bool>(nameof(_trimming));
            }

            _service = NovelGame.GetService<InputFormService>();

            _service.Show(_type, _label, isTrimming);

            _service.OnSubmit += OnSubmit;
        }

        private void OnSubmit(string text)
        {
            _service.OnSubmit -= OnSubmit;
            _service.Hide();

            _output = text;

            StopTask();
        }

        public override object GetValue(NodePort port)
        {
            return _output;
        }
    }
}
