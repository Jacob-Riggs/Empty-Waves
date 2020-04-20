using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomPropertyDrawer(typeof(MarkImportantInfo))]
public class ImportantInfoDrawer : PropertyDrawer {

    public GUIStyle style = new GUIStyle();
    public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
    {
        style.normal.textColor = Color.red;

        EditorGUI.LabelField(position, label, style);

        position.x += EditorGUIUtility.labelWidth;

        EditorGUI.PropertyField(position, property, GUIContent.none);
    }

}
