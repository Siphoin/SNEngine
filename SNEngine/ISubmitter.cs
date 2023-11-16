using UnityEngine.Events;

namespace SNEngine
{
    public interface ISubmitter
    {
        event UnityAction<string> OnSubmit;
    }
}
