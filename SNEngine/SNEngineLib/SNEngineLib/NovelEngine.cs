using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SNEngineLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace SNEngineLib
{
    public class NovelEngine : INovelEngine
    {
        private int _currentIndexLabel = -1;

        private List<ILabel> _labels;

        private SpriteBatch _spriteBatch;

        private GraphicsDevice _graphicsDevice;

        private GraphicsDeviceManager _graphics;

        private ContentManager _contentManager;

        private ILabel _currentLabel;

        public ICollection<ILabel> LabelsList => _labels;

        public ILabel CurrentLabel => _currentLabel;

        public NovelEngine (SpriteBatch spriteBatch, GraphicsDevice graphicsDevice, GraphicsDeviceManager graphicsDeviceManager, ContentManager contentManager)
        {
            _labels = new List<ILabel>();

            _spriteBatch = spriteBatch;
            _graphicsDevice = graphicsDevice;
            _graphics = graphicsDeviceManager;
            _contentManager = contentManager;
            
        }

        public void AddLabel (ILabel label)
        {
            if (label == null)
            {
                throw new NullReferenceException("this label is null");
            }

            if (_labels.Contains(label))
            {
                throw new Exception("this label exits");
            }

            label.SetSpriteBatch(_spriteBatch);

            label.SetGraphicDevice(_graphicsDevice);

            label.SetContentManager(_contentManager);

            label.SetGraphicDeviceManager(_graphics);

            _labels.Add(label);


            if (string.IsNullOrEmpty(label.Name))
            {
                label.Name = string.Format("Label_{0}", _labels.Count);
            }

#if DEBUG
            Debug.WriteLine($"added new label: {label.Name}");
#endif

            if (_labels.Count == 1)
            {
                _currentIndexLabel = 0;

                JumpToLabel(label);
            }


        }

        public void JumpToLabel(ILabel label)
        {
            if (_currentLabel != null)
            {
                _currentLabel.Dispose();
            }

            _currentLabel = label;

#if DEBUG
            Debug.WriteLine($"jumped to label: {_currentLabel.Name}");
#endif
        }
    }
}
