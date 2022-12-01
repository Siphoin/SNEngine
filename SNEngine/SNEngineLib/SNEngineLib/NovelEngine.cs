using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using SNEngineLib.Content;
using SNEngineLib.Converters;
using SNEngineLib.Core;
using SNEngineLib.Graphic;
using SNEngineLib.Graphic.GUI;
using SNEngineLib.Graphic.GUI.Controls;
using SNEngineLib.Interfaces;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;

namespace SNEngineLib
{
    public class NovelEngine : Component, INovelEngine
    {
        private bool _isFirstLabel;

        private int _currentIndexLabel = -1;

        public event Action<ILabel> LabelChanged;

        private List<ILabel> _labels;

        private List<Component> _components;

        private Dictionary<string, ICharacter> _characters;

        private SpriteBatch _spriteBatch;

        private GraphicsDevice _graphicsDevice;

        private GraphicsDeviceManager _graphics;

        private ContentManager _contentManager;

        private ContentPipeline _contentPipeline;

        private PanelDialog _panelDialog;

        private static INovelEngine _instance;

        public int CountLabels { get { return _labels.Count; } }

        public IDictionary<string, ICharacter> Characters => _characters;

        public static INovelEngine Current => _instance;

        public IContentPipeline ContentPipeline => _contentPipeline;


        private ILabel _currentLabel;

        public ICollection<ILabel> LabelsList => _labels;

        public ILabel CurrentLabel => _currentLabel;

        public IPanelDialog PanelDialog => _panelDialog;

        public NovelEngine (SpriteBatch spriteBatch, GraphicsDevice graphicsDevice, GraphicsDeviceManager graphicsDeviceManager, ContentManager contentManager, GameWindow gameWindow)
        {
            if (_instance != null)
            {
                throw new Exception("Novel engine already initialized");
            }

            _instance = this;

            _labels = new List<ILabel>();

            _components = new List<Component>();


            _spriteBatch = spriteBatch;
            _graphicsDevice = graphicsDevice;
            _graphics = graphicsDeviceManager;
            _contentManager = contentManager;

            Screen.Initialize(_graphics);

            Window.Initialize(_graphics, gameWindow);

            _contentPipeline = new ContentPipeline();

            _contentPipeline.Initialize(contentManager);

            _contentPipeline.LoadData();

            while (!_contentPipeline.IsFinishLoadingAssetsEngine)
            {
                Thread.Sleep(1000);
            }

            _panelDialog = new PanelDialog();

            _panelDialog.Initialize();

            AddComponent(_panelDialog);

            _isFirstLabel = true;
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

            if (CountLabels == 1)
            {
                JumpToLabel(label);
            }

            else if (CountLabels > 1)
            {
                _isFirstLabel = false;
            }


        }

        public void JumpToLabel(ILabel label)
        {
            if (_currentLabel == label)
            {
                return;
            }

            _currentLabel?.Dispose();

            _currentLabel = label;

            _currentIndexLabel = _labels.IndexOf(label);

            _currentLabel.Initialize();

            if (!_isFirstLabel)
            {
                LabelChanged?.Invoke(_currentLabel);
            }






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

        public bool CharacterExits(string id)
        {
            return _characters.ContainsKey(id);
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            _graphicsDevice.Clear(Color.Gray);

            spriteBatch.Begin(SpriteSortMode.BackToFront);

            _currentLabel?.Display();

            foreach (var component in _components)
            {
                component.Draw(gameTime, spriteBatch);
            }

            spriteBatch.End();
        }

        public override void Update(GameTime gameTime)
        {
            foreach (var component in _components)
            {
               if (component.IsUpdatable)
                {
                 component.Update(gameTime);
                }

            }

            _currentLabel?.Update(gameTime);
        }

        public  void Dispose()
        {
            _panelDialog?.Dispose();
        }
    }
}
