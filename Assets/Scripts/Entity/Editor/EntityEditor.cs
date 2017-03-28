using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(Entity))]
public class EntityEditor : Editor
{
    public override void OnInspectorGUI()
    {
        Entity entity = target as Entity;
        entity.Race = (RaceEnum)EditorGUILayout.EnumPopup("Race",entity.Race);
        entity.Type = (Entity.TypeEnum)EditorGUILayout.EnumPopup("Type", entity.Type);
        switch(entity.Race)
        {
            case RaceEnum.Human:
                switch(entity.Type)
                {
                    case Entity.TypeEnum.Building:
                        entity.ID = (Humain.Building) EditorGUILayout.EnumPopup("Name", entity.ID);                 
                        break;
                    case Entity.TypeEnum.Unite:
                        entity.ID = (Humain.Unite) EditorGUILayout.EnumPopup("Name", entity.ID);
                        break;
                }
                break;
            case RaceEnum.Luminen:
                switch(entity.Type)
                {
                    case Entity.TypeEnum.Building: break;
                    case Entity.TypeEnum.Unite: break;
                }
                break;
        }
    }
}
