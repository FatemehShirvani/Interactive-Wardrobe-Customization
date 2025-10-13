using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(SwitchScene))] // Replace CanvasSwitcher with your script’s class name
public class CanvasSwitcherEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // Draw the default inspector
        DrawDefaultInspector();

        // Reference to your component
        SwitchScene switcher = (SwitchScene)target;

        GUILayout.Space(10);
        GUILayout.Label("Debug Toggle", EditorStyles.boldLabel);

        // Button to switch to Character
        if (GUILayout.Button("Switch to Character"))
        {
            switcher.SwitchToCharacter();
        }

        // Button to switch to Closet
        if (GUILayout.Button("Switch to Closet"))
        {
            switcher.SwitchToCloset();
        }
    }
}
