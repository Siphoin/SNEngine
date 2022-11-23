using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SNEngineLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace SNEngineLib
{
    public class NovelEngine : Component, INovelEngine
    {
        private int _currentIndexLabel = -1;

        private List<ILabel> _labels;

        private List<Component> _components;

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

            _components = new List<Component>();


            _spriteBatch = spriteBatch;
            _graphicsDevice = graphicsDevice;
            _graphics = graphicsDeviceManager;
            _contentManager = contentManager;

            Screen.Initialize(_graphics);
            
        }

        public void AddLabel (ILabel label)
        {
            if (label == null)
            {
                throw new ArgumentNullException("this label is null");
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
                JumpToLabel(label);
            }


        }

        public void JumpToLabel(ILabel label)
        {
            _currentLabel?.Dispose();

            _currentLabel = label;

            _currentIndexLabel = _labels.IndexOf(label);

            _currentLabel.Initialize();

#if DEBUG
            Debug.WriteLine($"jumped to label: {_currentLabel.Name}");
#endif
        }

        public void JumpToLabel(string labelName)
        {
            try
            {
                ILabel label = _labels.Single(x => x.Name == labelName);

                JumpToLabel(label);
            }
            catch (Exception)
            {

                throw;
            }
        }

        private void AddComponent(Component component)
        {
            if (component == null)
            {
                throw new ArgumentNullException("component is null");
            }

            if (_components.Contains(component))
            {
                throw new ArgumentException("component contains");
            }

            _components.Add(component);
        }

        private void RemoveComponent(Component component)
        {
            if (component == null)
            {
                throw new ArgumentNullException("component is null");
            }

            if (!_components.Contains(component))
            {
                throw new ArgumentException("component not contains on list");
            }

            _components.Remove(component);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _currentLabel?.Display();

            foreach (var component in _components)
            {
                component.Draw(gameTime, spriteBatch);
            }
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
            {
                component.Update(gameTime);
            }
        }
    }
}
