using SiphoinUnityHelpers.XNodeExtensions;
using SNEngine.CharacterSystem;
using SNEngine.Debugging;
using SNEngine.Repositories;
using SNEngine.Services;
using System;
using System.Collections;
using System.Collections.Generic;

namespace SNEngine
{
    public static class TextParser
    {
        
        public static string ParseWithProperties (string text, BaseGraph graph) 
        {
            var varitables = graph.Varitables;

            var characters = NovelGame.GetRepository<CharacterRepository>().Characters;

            var globalVaritables = NovelGame.GetService<VaritablesContainerService>().GlobalVaritables;

            var dictonaries = new Dictionary<string, object>
             {
            { "[Property=", varitables },
            { "[GlobalProperty=", globalVaritables },
            {"[Character=", characters }

             };

            foreach (var pair in dictonaries)
            {
                IDictionary dictionary = pair.Value as IDictionary;

                foreach (DictionaryEntry item in dictionary)
                {
                    if (item.Value is VaritableNode)
                    {
                        VaritableNode node = item.Value as VaritableNode;

                        string attribute = $"{pair.Key}{node.Name}]";
          
                        if (text.Contains(pair.Key, StringComparison.Ordinal) && attribute.Contains(node.Name, StringComparison.Ordinal))
                        {
                            ReplacePart(ref text, attribute, node.GetCurrentValue().ToString());
                        }

                        
                    }

                    else if (item.Value is Character)
                    {
                        Character character = item.Value as Character;

                        string attribute = $"{pair.Key}{character.name}]";

                        if (text.Contains(pair.Key, StringComparison.Ordinal) && attribute.Contains(character.name, StringComparison.Ordinal))
                        {
                            ReplacePart(ref text, attribute, character.GetName());
                        }


                    }
                }
                }
            

            return text;
            
        }



        private static void ReplacePart (ref string text, string attribute, string newValue)
        {
            text = text.Replace(attribute, newValue);
        }
    }
}
