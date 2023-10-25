using System.Collections.Generic;

namespace SNEngine.SelectVariantsSystem
{
    public interface IVariantsSelectWindow : IShowable, IHidden, IShowerVariants, ISeterData<IEnumerable<string>>, ISelectableVariant
    {
    }
}
