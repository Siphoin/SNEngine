using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SNEngineLib.Interfaces
{
    public interface IImage : IGraphicObject
    {
        Texture2D GetTexture();
    }
}
