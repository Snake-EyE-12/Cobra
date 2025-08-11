#if  UNITY_EDITOR
    
using System;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Cobra.Utilities
{
    public static class ConsoleUtils
    {
        static MethodInfo _clearConsoleMethod;
        static MethodInfo clearConsoleMethod {
            get {
                if (_clearConsoleMethod == null) {
                    Assembly assembly = Assembly.GetAssembly (typeof(SceneView));
                    Type logEntries = assembly.GetType ("UnityEditor.LogEntries");
                    _clearConsoleMethod = logEntries.GetMethod ("Clear");
                }
                return _clearConsoleMethod;
            }
        }

        public static void ClearLog() {
            clearConsoleMethod.Invoke (new object (), null);
        }
    }
}

#endif
