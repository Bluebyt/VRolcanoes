using UnityEngine;
using System.Collections;
using Assets.Scripts.Core;
using UnityEditor;

[CustomEditor(typeof (PlaybackController))]
public class PlaybackControllerEditor : Editor {

    public override void OnInspectorGUI()
    {
        PlaybackController playbackController = (PlaybackController)target;
        DrawDefaultInspector();
        EditorGUILayout.BeginVertical();
        if (GUILayout.Button("Start Playback"))
        {
            playbackController.StartPlayback();
        }
        if (GUILayout.Button("Pause Playback"))
        {
            playbackController.PausePlayback();
        }
        if (GUILayout.Button("Reset Playback"))
        {
            playbackController.Reset();
        }
        EditorGUILayout.EndVertical();

    }
}
