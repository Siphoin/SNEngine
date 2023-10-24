using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

namespace SNEngine.Debugging
{
    public static class NovelGameDebug
    {
        private static readonly Dictionary<DebugType, string> _colorsDebug = new Dictionary<DebugType, string>()
        {
            {DebugType.Message, "#29baa9" },
            {DebugType.Error, "#ba2929" },
            {DebugType.Warning, "#bab529" }
        };


        public static void Log (object logTarget)
        {
            string message = FormatMessage(logTarget, DebugType.Message);

            Debug.Log(message);
        }

        public static void LogError(object logTarget)
        {
            string message = FormatMessage(logTarget, DebugType.Error);

            Debug.LogError(message);
        }

        public static void LogWarning(object logTarget)
        {
            string message = FormatMessage(logTarget, DebugType .Warning);

            Debug.LogWarning(message);
        }

        private static string FormatMessage (object message, DebugType debugType)
        {
            return $"<color={_colorsDebug[debugType]}>[SNEngine {debugType}]</color> {message}";
        }
    }

    public enum DebugType
    {
        Message,
        Error,
        Warning,
    }
}
