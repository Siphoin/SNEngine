using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SNEngineLib.Interfaces;

namespace SNEngineLib
{
    public abstract class Component : IUpdatableComponent, IDrawableComponent
    {
        public bool IsUpdatable { get; protected set; } = true;
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        public abstract void Update(GameTime gameTime);
    }
}
