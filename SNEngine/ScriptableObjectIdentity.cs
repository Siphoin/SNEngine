using SiphoinUnityHelpers.XNodeExtensions.Attributes;
using System;
using UnityEngine;

namespace SNEngine
{
    public class ScriptableObjectIdentity : ScriptableObject, Iidentity
    {
        [SerializeField, ReadOnly] private string _guid = Guid.NewGuid().ToString();

        public string GUID => _guid;
    }
}
