using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(HealOverTime))]
public class HealOverTimeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        HealOverTime healOverTime = target as HealOverTime;
        healOverTime.Amount = EditorGUILayout.IntField("Amount", healOverTime.Amount);
        EditorGUILayout.BeginHorizontal();
        healOverTime.RepeatRate = EditorGUILayout.FloatField("Repeat every", healOverTime.RepeatRate);
        EditorGUILayout.LabelField("second(s)");
        EditorGUILayout.EndHorizontal();
    }
}
