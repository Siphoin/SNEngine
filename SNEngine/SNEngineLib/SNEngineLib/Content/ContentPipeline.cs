using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SNEngineLib.Exceptions;
using SNEngineLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace SNEngineLib.Content
{
    internal  class ContentPipeline : IContentPipeline, IDisposable
    {
        private const string PATH_TO_FILE = "assets_path_list.txt";

        private const string PATH_ROOT_ENGINE = "engine_assets/";

        private List<string> _typesList;

        private Dictionary<string, object> _assets;
        
        private ContentManager _contentManager;

        public bool IsFinishLoadingAssetsEngine { get; private set; } = false;

        internal void Initialize(ContentManager contentManager)
        {
            if (contentManager == null)
            {
                throw new ArgumentNullException(nameof(contentManager));
            }

            _contentManager = contentManager;

            _typesList = new List<string>()
            {
                "Texture2D",
                "SpriteFont",
            };

            _assets = new Dictionary<string, object>();

#if DEBUG
            Debug.WriteLine("content pipeline ready");
#endif
        }

        internal void LoadData ()
        {

            LoadAssets(File.ReadAllText(PATH_TO_FILE));
        }

        private void LoadAssets (string data)
        {
            if (string.IsNullOrEmpty(data))
            {
                throw new ArgumentException($"data from {PATH_TO_FILE} is empty");
            }

            string[] assetsStrings = data.Split(Environment.NewLine);

            if (assetsStrings.Length == 0)
            {
                throw new ParseException($"data of file {PATH_TO_FILE} not valid");
            }



            for (int i = 0; i < assetsStrings.Length; i++)
            {
                string[] dataAsset = assetsStrings[i].Split(": ");

                if (dataAsset.Length == 0)
                {
                    throw new ParseException($"data of asset in index {i} not contains data");
                }

                string typeString = dataAsset[0];


                if (!_typesList.Contains(typeString))
                {
                    throw new ParseException($"type of asset {typeString} not found");
                }

                string pathAsset = dataAsset[1];

                

                string fullPathAsset = PATH_ROOT_ENGINE + pathAsset;

                object asset = null;

                switch (typeString)
                {
                    case "Texture2D":
                        asset = _contentManager.Load<Texture2D>(fullPathAsset);
                    break;

                    case "SpriteFont":
                        asset = _contentManager.Load<SpriteFont>(fullPathAsset);
                        break;
                    default:
                        throw new ParseException($"type of asset {typeString} not found");
                }
                _assets.Add(pathAsset, asset);


            }

           IsFinishLoadingAssetsEngine = true;

#if DEBUG
            Debug.WriteLine($"loaded {_assets.Count} engine assets");
#endif
        }

        public object GetAssetEngine(string path)
        {
            if (!_assets.ContainsKey(path))
            {
                throw new KeyNotFoundException($"asset in path {path} not found");
            }

            return _assets[path];
        }

        public void Dispose()
        {
          _assets?.Clear();
          _contentManager?.Unload();
          _contentManager?.Dispose();
          
        }
    }
}
