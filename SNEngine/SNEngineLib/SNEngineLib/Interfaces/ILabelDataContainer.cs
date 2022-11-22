using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;

namespace SNEngineLib.Interfaces
{
    public interface ILabelDataContainer : IDisposable
    {

        ICollection<IImage> Images { get; }

        public IImage Background { get; }

        void SetContentManager(ContentManager manager);

        T LoadAsset<T>(string path, bool isImage = false);

        void LoadBackground(string path);


    }
}
