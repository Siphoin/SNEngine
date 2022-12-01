using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace SNEngineLib.Interfaces
{
    public interface ILabel : IDisposable, IUpdatableComponent
    {
        string Name { get; set; }

        void Display();

        void Initialize();

        void SetGraphicDevice(GraphicsDevice graphicsDevice);

        void SetGraphicDeviceManager(GraphicsDeviceManager graphicsDevice);

        void SetSpriteBatch(SpriteBatch spriteBatch);


    }
}
