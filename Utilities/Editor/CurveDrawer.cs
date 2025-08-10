#if  UNITY_EDITOR
   
using UnityEngine;
using UnityEditor;
using Cobra.Utilities;

namespace Cobra.CustomEditor
{
    [CustomPropertyDrawer(typeof(Curve))]
    public class CurveDrawer : PropertyDrawer
    {
        private const float Padding = 2f;

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            return EditorGUIUtility.singleLineHeight * 3 + Padding * 4;
        }

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            SerializedProperty curve = property.FindPropertyRelative("curve");
            SerializedProperty xMin = property.FindPropertyRelative("xMin");
            SerializedProperty xMax = property.FindPropertyRelative("xMax");
            SerializedProperty yMin = property.FindPropertyRelative("yMin");
            SerializedProperty yMax = property.FindPropertyRelative("yMax");

            EditorGUI.BeginProperty(position, label, property);

            float lineHeight = EditorGUIUtility.singleLineHeight;
            float spacing = 4f;
            float labelWidth = 45f;

            float y = position.y;

            // Draw curve field normally
            Rect curveRect = new Rect(position.x, y, position.width, lineHeight);
            EditorGUI.PropertyField(curveRect, curve, label);
            y += lineHeight + Padding;

            // Indent manually
            int indentLevel = EditorGUI.indentLevel;
            float indentWidth = 15f;
            float indentOffset = indentLevel * indentWidth;

            float availableWidth = position.width - indentOffset;
            float fieldWidth = (availableWidth - spacing * 3 - labelWidth * 2) / 2f;

            float xStart = position.x + indentOffset;

            // X Min / Max
            DrawLabeledField(xStart, y, xMin, "X Min", labelWidth, fieldWidth);
            DrawLabeledField(xStart + labelWidth + fieldWidth + spacing, y, xMax, "X Max", labelWidth, fieldWidth);
            y += lineHeight + Padding;

            // Y Min / Max
            DrawLabeledField(xStart, y, yMin, "Y Min", labelWidth, fieldWidth);
            DrawLabeledField(xStart + labelWidth + fieldWidth + spacing, y, yMax, "Y Max", labelWidth, fieldWidth);

            EditorGUI.EndProperty();
        }

        private void DrawLabeledField(float x, float y, SerializedProperty prop, string label, float labelWidth, float fieldWidth)
        {
            var labelRect = new Rect(x, y, labelWidth, EditorGUIUtility.singleLineHeight);
            var fieldRect = new Rect(x + labelWidth, y, fieldWidth, EditorGUIUtility.singleLineHeight);
            EditorGUI.LabelField(labelRect, label);
            EditorGUI.PropertyField(fieldRect, prop, GUIContent.none);
        }
    }
}


#endif
