using SNEngine.Animations;
using UnityEngine;

namespace SNEngine.BackgroundSystem
{
    public interface IBackgroundRenderer : IResetable, IFadeable, IFlipable, IChangeableColor, IMovableByDirection, ISeterData<Sprite>
    {
        void Clear();
    }
}