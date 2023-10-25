using System;

namespace SNEngine.SelectVariantsSystem
{
    public interface ISelectableVariant
    {
        event Action<int> OnSelect;
    }
}
