using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SwitchScene))]

public class CanvasSwitcherEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        SwitchScene switcher = (SwitchScene)target;

        GUILayout.Space(10);
        GUILayout.Label("Debug Toggle", EditorStyles.boldLabel);

        if (GUILayout.Button("Switch to Character"))
        {
            switcher.SwitchToCharacter();
        }

        if (GUILayout.Button("Switch to Closet"))
        {
            switcher.SwitchToCloset();
        }
    }
}
