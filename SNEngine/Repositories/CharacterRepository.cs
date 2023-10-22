using SNEngine.CharacterSystem;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

namespace SNEngine.Repositories
{
    public class CharacterRepository : RepositoryBase
    {
        private Dictionary<string, Character> _characters;

        public IDictionary<string, Character> Characters => _characters;

        public override void Initialize()
        {
            _characters = new Dictionary<string, Character>();

            var characters = Resources.LoadAll<Character>("Characters");

            foreach (var character in characters)
            {
                _characters.Add(character.name, character);
            }
        }

        public Character FindByName (string name)
        {
            if (_characters.ContainsKey(name))
            {
                return _characters[name];
            }

            else
            {
                throw new NullReferenceException($"character by name {name} not found");
            }
        }

        public Character FindByGUID(string guid)
        {
            var character = _characters.SingleOrDefault(x => x.Value.GUID == guid).Value;

            if (character != null)
            {
                return character;
            }

            else
            {
                throw new NullReferenceException($"character by Guid {guid} not found");
            }
        }
    }
}
