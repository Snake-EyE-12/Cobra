#if UNITY_EDITOR
using UnityEditor;
using System.IO;
using UnityEngine;

namespace Cobra.Utilities.Tools
{
    public static class ProjectSetup
    {
        public static string rootProject = "_Project";
        [MenuItem("Tools/Setup/Create Folders")]
        public static void CreateDefaultFolders() {
            Directory.CreateDirectory(Path.Combine(Application.dataPath, rootProject));
            AssetDatabase.Refresh();
        }
        public static void Dir(string root, params string[] dir) {
            string fullPath = Path.Combine(Application.dataPath, root);
            foreach (string newDir in dir) {
                Directory.CreateDirectory(Path.Combine(fullPath, newDir));
            }
        }
    }
}
#endif