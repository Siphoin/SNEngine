using SNEngine.Debugging;
using System.Collections.Generic;
using UnityEngine;

namespace SNEngine.Repositories
{
    public class MaterialRepository : RepositoryBase
    {

        private Dictionary<string, Material> _materials;

        public override void Initialize()
        {
            var materialPrefix = nameof(Material);

            var materials = Resources.LoadAll<Material>($"{materialPrefix}s");

            _materials = new Dictionary<string, Material>();

            for ( int i = 0; i < materials.Length; i++ )
            {
                string name = materials[i].name.Replace($"_{materialPrefix.ToLower()}", string.Empty);

                _materials.Add(name, materials[i]);
            }

            NovelGameDebug.Log($"loaded {_materials.Count} material(s).");
        }

        public Material GetMaterial(string name)
        {
            if ( _materials.ContainsKey(name))
            {
                return _materials[name];
            }

            else
            {
                throw new KeyNotFoundException($"material with name {name} not found");
            }
        }
    }
}
