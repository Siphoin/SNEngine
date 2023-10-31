using SNEngine.Animations;
using UnityEngine;

namespace SNEngine.BackgroundSystem
{
    public interface IBackgroundRenderer : IResetable, IFadeable, IFlipable, IChangeableColor, IDissolveable, IBlackAndWhiteSupport, IIlluminatiionable, ISolidable, ICeliable, IMovableByDirection, ISeterData<Sprite>
    {
        bool UseTransition { get; set; }

        void Clear();
    }
}