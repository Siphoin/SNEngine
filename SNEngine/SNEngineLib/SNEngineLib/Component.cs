using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SNEngineLib.Interfaces;
using System;

namespace SNEngineLib
{
    public abstract class Component : IUpdatableComponent, IDrawableComponent
    {

        public bool IsUpdatable { get; protected set; } = true;

        public bool IsDrawable { get; protected set; } = true;
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        public abstract void Update(GameTime gameTime);
    }
}
