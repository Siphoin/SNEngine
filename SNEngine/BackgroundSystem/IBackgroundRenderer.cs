using UnityEngine;

namespace SNEngine.BackgroundSystem
{
    public interface IBackgroundRenderer : IResetable, ISeterData<Sprite>
    {
        void Clear();
    }
}