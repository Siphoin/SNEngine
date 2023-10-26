using SNEngine.Attributes;
using UnityEditor;
using UnityEngine;

namespace SNEngine.Editor
{
    [CustomPropertyDrawer(typeof(LeftToggleAttribute))]
    public class LeftTogglePropertyDrawer : PropertyDrawer
    {
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {

           property.boolValue = EditorGUI.ToggleLeft(position, label.text, property.boolValue);
        }
    }
}
