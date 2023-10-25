using SiphoinUnityHelpers.XNodeExtensions;
using System.Collections.Generic;
using UnityEngine;

namespace SNEngine.Graphs
{
    [CreateAssetMenu(menuName = "SNEngine/VaritableContainerGraph")]
    public class VaritableContainerGraph : BaseGraph, IContainerVaritables
    {
        public IDictionary<string, VaritableNode> GlobalVaritables => Varitables;

        public override void Execute()
        {
            BuidVaritableNodes();
        }
    }
}
