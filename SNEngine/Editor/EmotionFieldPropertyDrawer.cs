using SNEngine.Attributes;
using SNEngine.CharacterSystem;
using System;
using System.Linq;
using UnityEditor;
using UnityEngine;

namespace SNEngine.Editor
{
    [CustomPropertyDrawer(typeof(EmotionFieldAttribute))]
    public class EmotionFieldPropertyDrawer : PropertyDrawer
    {
        private int _selectedIndex;

        private static Color32 _colorWarning = Color.clear;

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            CharacterNode characterNode = property.serializedObject.targetObject as CharacterNode;

            if (characterNode.Character is null)
            {
                if (_colorWarning ==  Color.clear)
                {
                    _colorWarning = new Color32(250, 185, 185, 255);
                }
                GUIStyle style = new (GUI.skin.label);



                style.normal.textColor = _colorWarning;

                style.alignment = TextAnchor.MiddleCenter;

                EditorGUI.LabelField(position, "Character not seted", style);

                 return;
            }

            else
            {
                var emotions = characterNode.Character.Emotions.ToArray();

                var emotionsVariants = emotions.Select(e => e.Name).ToArray();

                _selectedIndex = Array.IndexOf(emotionsVariants, property.stringValue);

                _selectedIndex = EditorGUI.Popup(position, label.text, _selectedIndex, emotionsVariants);

                property.stringValue = emotionsVariants[_selectedIndex];
            }
        }
    }
}