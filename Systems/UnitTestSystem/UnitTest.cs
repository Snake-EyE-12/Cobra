using System;
using System.Linq;
using System.Reflection;
using Cobra.Utilities;
using JetBrains.Annotations;
using NaughtyAttributes;
using UnityEngine;

namespace Cobra.UnitTesting
{
    public abstract class UnitTest : MonoBehaviour
    {
        [Button]
        private void RunTests()
        {
        #if UNITY_EDITOR
            ConsoleUtils.ClearLog();
        #endif
            Type currentType = this.GetType();
            Assembly assembly = currentType.Assembly;
            var methods = assembly.GetTypes()
                .Where(t => t == currentType)
                .SelectMany(t => t.GetMethods())
                .Where(m => m.GetCustomAttributes(typeof(TestAttribute), false).Length > 0)
                .ToArray();
            Debug.Log($"Running {methods.Length} Tests in class {currentType.Name}");
            foreach (var m in methods)
            {
                UnityEngine.Debug.Log($"Running Test: {m.Name}");
                m.Invoke(this, null);
            }
        }
    }
    [AttributeUsage(AttributeTargets.Method)]
    public class TestAttribute : Attribute
    {
        
    }
}
