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

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            CharacterNode characterNode = property.serializedObject.targetObject as CharacterNode;

            if (characterNode.Character is null)
            {
                EditorGUI.LabelField(position, "Character not seted");
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