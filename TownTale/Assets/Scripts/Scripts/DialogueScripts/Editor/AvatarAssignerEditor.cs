using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(AvatarAssigner))]
public class AvatarAssignerEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector();

        AvatarAssigner avatarAssigner = (AvatarAssigner)target;
        if (GUILayout.Button("Assign Avatars"))
        {
            avatarAssigner.AssignAvatars();
        }
    }
}
