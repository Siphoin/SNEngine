using System;
using UnityEngine;

namespace SNEngine.Extensions
{
    public static class MulticastDelegateExtensions
    {
        public static bool IsHaveSubcribe (this MulticastDelegate multicastDelegate)
        {
            return multicastDelegate is null ? false : multicastDelegate.GetInvocationList().Length > 0;
        }
    }
}
