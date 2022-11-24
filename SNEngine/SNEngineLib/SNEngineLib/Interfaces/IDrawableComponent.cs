using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace SNEngineLib.Interfaces
{
    public interface IDrawableComponent
    {
        void Draw(GameTime gameTime, SpriteBatch spriteBatch);
    }
}
