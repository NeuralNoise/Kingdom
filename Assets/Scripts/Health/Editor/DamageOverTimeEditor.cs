using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(DamageOverTime))]
public class DamageOverTimeEditor : Editor
{
    public override void OnInspectorGUI()
    {
        DamageOverTime damageOverTime = target as DamageOverTime;
        damageOverTime.Amount = EditorGUILayout.IntField("Amount", damageOverTime.Amount);
        EditorGUILayout.BeginHorizontal();
        damageOverTime.RepeatRate = EditorGUILayout.FloatField("Repeat every", damageOverTime.RepeatRate);
        EditorGUILayout.LabelField("second(s)");
        EditorGUILayout.EndHorizontal();
    }
}
