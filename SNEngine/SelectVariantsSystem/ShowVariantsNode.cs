using Cysharp.Threading.Tasks;
using SiphoinUnityHelpers.XNodeExtensions.AsyncNodes;
using SiphoinUnityHelpers.XNodeExtensions.Attributes;
using SNEngine.Services;
using System.Linq;
using UnityEngine;
using XNode;
namespace SNEngine.SelectVariantsSystem
{
    public class ShowVariantsNode : AsyncNode
    {
        private const int START_VALUE_INDEX = -1;

        [SerializeField, Input(dynamicPortList = true, connectionType = ConnectionType.Override), ReadOnly(ReadOnlyMode.OnEditor)] private string[] _variants = new string[]
        {
            "Variant A",
            "Variant B"
        };

        [Output(ShowBackingValue.Never), SerializeField] private int _selectedIndex;

        private int _index;

        public override void Execute()
        {
            base.Execute();

            Show().Forget();


        }

        public override object GetValue(NodePort port)
        {
            return _index;
        }

        private async UniTask Show ()
        {
            _index = START_VALUE_INDEX;

            var variants = _variants.ToArray();

            for (int i = 0; i < variants.Length; i++)
            {
                string fieldName = $"{nameof(_variants)} {i}";

                var port = GetInputPort(fieldName);

                if (port.Connection != null)
                {
                    variants[i] = GetInputValue<string>(fieldName);
                }
            }

            var serviceShowVariants = NovelGame.GetService<SelectVariantsService>();

            serviceShowVariants.OnSelect += OnSelect;

            serviceShowVariants.ShowVariants(variants);

            while (_index == START_VALUE_INDEX)
            {
                await UniTask.WaitUntil(() => _index == START_VALUE_INDEX, cancellationToken: TokenSource.Token);
            }

        }

        private void OnSelect(int index)
        {
            var serviceShowVariants = NovelGame.GetService<SelectVariantsService>();

            serviceShowVariants.OnSelect -= OnSelect;

            _index = index;

            StopTask();

        }
    }
}
