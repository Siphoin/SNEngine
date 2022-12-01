using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SNEngineLib.Graphic;
using SNEngineLib.Interfaces;
using System;
using System.Collections.Generic;

namespace SNEngineLib.Core
{
    public class Character : Component, ICharacter
    {
        private Image _image;

        public event Action<string, string> OnSayoing;

        private Dictionary<string, Texture2D> _states;

        public string Id { get; private set; }

        internal bool IsDisplayed { get; private set; }

        public Color ColorName { get; private set; }

        public Character (string id, Color colorName)
        {
            if (string.IsNullOrEmpty(id))
            {
                throw new ArgumentException("id of character not must be empty");
            }

            if (NovelEngine.Current.CharacterExits(id))
            {
                throw new ArgumentException($"ID character {id} has exits on engine characters DB");
            }


            Id = id.Trim();

            ColorName = colorName;

            Texture2D shadowCharacter = NovelEngine.Current.ContentPipeline.GetAssetEngine<Texture2D>("templates/shadow_character");


            _image = new Image(shadowCharacter);

            Vector2 startPosition = new Vector2(Window.Width / 2 - (_image.Width / 2), 0);

            _image.Position = startPosition;

            IsDisplayed = true;

            _states = new Dictionary<string, Texture2D>();

            IsUpdatable = false;


        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            if (!IsDisplayed)
            {
                return;
            }

            spriteBatch.Draw(_image.GetTexture(), _image.Position, _image.Color);
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public void Say(string name, string text)
        {
            OnSayoing?.Invoke(name, text);
        }

        public void Show (string emotion = "normal") => IsDisplayed = true;

        public void Hide () => IsDisplayed = false;

        public  void Dispose()
        {
            _image?.Dispose();
        }
    }
}
