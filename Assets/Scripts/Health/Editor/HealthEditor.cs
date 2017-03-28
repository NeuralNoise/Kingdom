using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Health))]
public class HealthEditor : Editor
{
    [SerializeField]
    int heal = 0;
    [SerializeField]
    int damage = 0;

    public override void OnInspectorGUI()
    {
        Health health = target as Health;
        health.MaxHP = EditorGUILayout.IntField("Max HP",health.MaxHP);
        EditorGUILayout.LabelField("Current HP",health.CurrentHP.ToString());
        EditorGUILayout.BeginHorizontal();

        heal = EditorGUILayout.IntField("Heal",heal);
        if (GUILayout.Button("Apply",GUILayout.Width(100)))
        {
            health.TakeHeal(heal);
        }
        EditorGUILayout.EndHorizontal();
        EditorGUILayout.BeginHorizontal();
        damage = EditorGUILayout.IntField("Damage",damage);
        if (GUILayout.Button("Apply", GUILayout.Width(100)))
        {
            health.TakeDamage(damage);
        }
        EditorGUILayout.EndHorizontal();
    }
}
