using UnityEditor;

[CustomEditor(typeof(RTSCamera))]
public class RTSCameraEditor : Editor
{
    bool m_showDisplacement = true;
    bool m_showRotation = true;
    bool m_showZoom = true;

    public override void OnInspectorGUI()
    {
        RTSCamera script = target as RTSCamera;
        m_showDisplacement = EditorGUILayout.Foldout(m_showDisplacement, "Displacement");
        if(m_showDisplacement)
        {
            EditorGUI.indentLevel = 1;
            script.DisplacementSpeed = EditorGUILayout.IntField("Speed",script.DisplacementSpeed);
            EditorGUI.indentLevel = 0;
        }
        m_showRotation = EditorGUILayout.Foldout(m_showRotation, "Rotation");
        if (m_showRotation)
        {
            EditorGUI.indentLevel = 1;
            script.RotationSpeed = EditorGUILayout.IntField("Speed", script.RotationSpeed);
            EditorGUI.indentLevel = 0;
        }
        m_showZoom = EditorGUILayout.Foldout(m_showZoom, "Zoom");
        if (m_showZoom)
        {
            EditorGUI.indentLevel = 1;
            script.ZoomSpeed = EditorGUILayout.IntField("Speed",script.ZoomSpeed);
            float max = script.MaxDistance;
            float min = script.MinDistance;
            EditorGUILayout.MinMaxSlider("Distances", ref min, ref max, 0.0f, 100.0f);
            script.MinDistance = (int) min;
            script.MaxDistance = (int) max;
            EditorGUILayout.LabelField("Min",min.ToString("0"));
            EditorGUILayout.LabelField("Max", max.ToString("0"));
            EditorGUI.indentLevel = 0;
        }
    }
}
