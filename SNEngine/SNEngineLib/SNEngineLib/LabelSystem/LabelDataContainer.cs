using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SNEngineLib.Graphic;
using SNEngineLib.Interfaces;
using System;
using System.Collections.Generic;

namespace SNEngineLib.LabelSystem
{
    internal class LabelDataContainer : ILabelDataContainer
    {
        private List<IImage> _images;

        private Image _background;

        private ContentManager _content;

        public ICollection<IImage> Images => _images;

        public IImage Background => _background;

        public LabelDataContainer ()
        {
            _images = new List<IImage>();
        }


        public void SetContentManager(ContentManager manager)
        {
            if (_content != null)
            {
                throw new Exception("content manager link seted on container label");
            }
            _content = manager;
        }

        public T LoadAsset<T>(string path, bool isImage = false)
        {
            T asset = _content.Load<T>(path);

            if (isImage)
            {
                CacheImage(asset);
            }

            return asset;
        }

        public void LoadBackground (string path)
        {
            try
            {
                Texture2D texture = _content.Load<Texture2D>(path);

                _background = new Image(texture);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void CacheImage<T>(T asset)
        {
            Type type = typeof(T);

            if (type == typeof(Texture2D))
            {
                object obj = asset;

                IImage image = new Image((Texture2D)obj);

                _images.Add(image);
            }
        }

        public void Dispose()
        {
            for (int i = 0; i < _images.Count; i++)
            {
                _images[i].Dispose();
            }

            _images.Clear();

            // fix unloading system

            _content.Unload();
        }
    }
}
