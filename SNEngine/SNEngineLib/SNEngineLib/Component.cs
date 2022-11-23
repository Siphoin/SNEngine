using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using SNEngineLib.Interfaces;

namespace SNEngineLib
{
    public abstract class Component : IUpdatableComponent
    {
        public abstract void Draw(GameTime gameTime, SpriteBatch spriteBatch);

        public abstract void Update(GameTime gameTime);
    }
}
