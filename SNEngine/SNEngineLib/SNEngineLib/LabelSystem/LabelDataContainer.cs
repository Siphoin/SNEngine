using Microsoft.Xna.Framework;
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

        public ICollection<IImage> Images => _images;

        public IImage Background => _background;

        private IContentPipeline ContentPipeline => NovelEngine.Current.ContentPipeline;

        public LabelDataContainer ()
        {
            _images = new List<IImage>();

        }

        public T LoadAsset<T>(string path, bool isImage = false)
        {
            T asset = ContentPipeline.LoadAsset<T>(path);

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
                Texture2D texture = ContentPipeline.LoadAsset<Texture2D>(path);

                _background = new Image(texture);

                _background.Origin = Vector2.Zero;
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
            _images.Clear();
        }
    }
}
