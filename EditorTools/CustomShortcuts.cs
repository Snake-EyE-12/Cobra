using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEditor;

namespace Cobra.Utilities.Tools
{
    public static class CustomShortcuts
    {
        [MenuItem("Edit/Shortcuts/Cobra/MaximizeOnPlay &p")]
        static void ToggleMaxPlay()
        {
            EditorWindow gameViewWindow;
            EditorWindow[] editorWindows = Resources.FindObjectsOfTypeAll<EditorWindow>();
            foreach (EditorWindow editorWindow in editorWindows)
            {
                if (editorWindow.GetType().Name == "GameView")
                {
                    gameViewWindow = editorWindow;
                    PropertyInfo propertyInfo = gameViewWindow.GetType().GetProperty("maximizeOnPlay", BindingFlags.Public | BindingFlags.Instance);
                    bool gameViewMaximized = (bool) (propertyInfo.GetValue(gameViewWindow, null));
                    propertyInfo.SetValue(gameViewWindow, !gameViewMaximized);
                    gameViewWindow.Repaint();
                }

            }
        }
        [MenuItem("Edit/Shortcuts/Cobra/InspectorDebugMode &d")]
        static void ToggleDebugNormalView()
        {
            EditorWindow inspectorWindow;
            EditorWindow[] editorWindows = Resources.FindObjectsOfTypeAll<EditorWindow>();
            foreach (EditorWindow editorWindow in editorWindows)
            {
                if (editorWindow.GetType().Name == "InspectorWindow")
                {
                    if (EditorWindow.focusedWindow == editorWindow)
                    {
                        inspectorWindow = editorWindow;
                        MethodInfo methodInfo = inspectorWindow.GetType().GetMethod("SetMode", BindingFlags.NonPublic | BindingFlags.Instance);
                        FieldInfo field = inspectorWindow.GetType().GetField("m_InspectorMode", BindingFlags.NonPublic | BindingFlags.Instance);
                        if ((InspectorMode)field.GetValue(inspectorWindow) == InspectorMode.Debug)
                        {
                            methodInfo.Invoke(inspectorWindow, new object[] { InspectorMode.Normal });
                        }
                        else methodInfo.Invoke(inspectorWindow, new object[] { InspectorMode.Debug });
                        break;
                    }
                }
            }
        }
        [MenuItem("Edit/Shortcuts/Cobra/LockInspector #q")]
        static void ToggleLockUnlockInspector()
        {
            ActiveEditorTracker.sharedTracker.isLocked = !ActiveEditorTracker.sharedTracker.isLocked;
            ActiveEditorTracker.sharedTracker.activeEditors[0].Repaint();
        }
    }
    
}