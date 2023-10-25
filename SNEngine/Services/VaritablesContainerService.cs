using SiphoinUnityHelpers.XNodeExtensions;
using SNEngine.Debugging;
using SNEngine.Graphs;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace SNEngine.Services
{
    public class VaritablesContainerService : IService, IContainerVaritables
    {
        private IContainerVaritables _containerVaritables;
        public IDictionary<string, VaritableNode> GlobalVaritables => _containerVaritables.GlobalVaritables;

        private const string PATH = "VaritableContainerGraph";

        public void Initialize()
        {
            var graph = Resources.Load<VaritableContainerGraph>(PATH);

            if (graph != null)
            {
                NovelGameDebug.Log($"{nameof(GlobalVaritables)} Container loaded. Build Varitables...");

                graph.Execute();

                StringBuilder stringBuilder = new StringBuilder();

                stringBuilder.AppendLine($"{nameof(GlobalVaritables)} Container finished Build.");

                foreach (var item in graph.GlobalVaritables)
                {
                    stringBuilder.AppendLine($"Key: {item.Key} Value: {item.Value.GetCurrentValue()} Type Node: {item.Value.GetType().Name}");
                }


                NovelGameDebug.Log(stringBuilder.ToString());

                _containerVaritables = graph;
            }

            else
            {
                NovelGameDebug.LogError($"{nameof(GlobalVaritables)} Container not found on path {PATH}");
            }
        }
    }
}
