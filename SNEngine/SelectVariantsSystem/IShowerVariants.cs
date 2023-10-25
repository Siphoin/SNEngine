using System.Collections.Generic;

namespace SNEngine.SelectVariantsSystem
{
    public interface IShowerVariants
    {
        void ShowVariants(IEnumerable<string> variants);
    }
}
