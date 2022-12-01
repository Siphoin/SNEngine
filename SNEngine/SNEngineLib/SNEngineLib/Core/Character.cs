using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SNEngineLib.Converters;
using SNEngineLib.Graphic;
using SNEngineLib.Interfaces;
using System;

namespace SNEngineLib.Core
{
    public class Character : Component, ICharacter
    {
        private Image _image;

        public string Id { get; private set; }

        public bool IsDisplayed { get; private set; }

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

            _image = new Image();

            IsDisplayed = false;
        }

        public Character(string id, string coloRHex)
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

            ColorName = HexColorConverter.ColorFromHex(coloRHex);

            _image = new Image();

            IsDisplayed = false;
        }

        public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_image.GetTexture(), _image.Position, _image.Color);
        }

        public override void Update(GameTime gameTime)
        {
            throw new NotImplementedException();
        }

        public void Say(string fileName)
        {
            throw new NotImplementedException();
        }

        public  void Dispose()
        {
            _image?.Dispose();
        }
    }
}
