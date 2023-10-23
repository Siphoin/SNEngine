using SNEngine.BackgroundSystem;
using UnityEngine;
using XNodeEditor;

namespace SNEngine.Editor
{
    [CustomNodeEditor(typeof(SetBackgroundNode))]
    public class SetBackgroundNodeEditor : NodeEditor
    {
        public override void OnBodyGUI()
        {
            SetBackgroundNode node = target as SetBackgroundNode;

            base.OnBodyGUI();

            if (node.Sprite != null)
            {
                Rect rect = new Rect(160, 55, 46, 46);

                GUI.DrawTexture(rect, node.Sprite.texture);
            }
        }
    }
}
