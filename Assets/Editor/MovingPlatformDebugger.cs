using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(MovingPlatform))]
public class MovingPlatformDebugger : Editor {


    private void OnSceneGUI() {

        MovingPlatform platform = (MovingPlatform)target;

        if (Application.isPlaying == false) {

            Handles.DrawLine(platform.transform.position, platform.endPos1);
            Handles.DrawLine(platform.transform.position, 2 * (Vector2)platform.transform.position - platform.endPos1);

            Vector2 newEndPos1 = Handles.PositionHandle(platform.endPos1, Quaternion.identity);
            if (EditorGUI.EndChangeCheck()) {
                Undo.RecordObject(platform, "changing endPos1");
                platform.endPos1 = newEndPos1;
            }
        }
        else {
            Handles.DrawLine(platform.initialPos, platform.endPos1);
            Handles.DrawLine(platform.initialPos, 2 * platform.initialPos - platform.endPos1);
        }
    }
}
