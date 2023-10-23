using SiphoinUnityHelpers.XNodeExtensions;
using SNEngine.CharacterSystem;
using System.Collections;

namespace SNEngine
{
    public static class TextParser
    {
        
        public static string ParseWithProperties (string text, params object[] dictionaries) 
        {

            foreach (IDictionary dictionary in dictionaries)
            {

                foreach (DictionaryEntry pair in dictionary)
                {
                    string keyProperty = $"[Property={pair.Key}]";

                    string characterProperty = $"[Character={pair.Key}]";

                    if (text.Contains(keyProperty))
                    {
                        VaritableNode varitableNode = pair.Value as VaritableNode;

                        text = text.Replace(keyProperty, varitableNode.GetCurrentValue().ToString());
                    }

                    else if (text.Contains(characterProperty))
                    {
                        Character character = pair.Value as Character;

                        text = text.Replace(characterProperty,  character.GetName());
                    }
                }
            }

            return text;
            
        }
    }
}
