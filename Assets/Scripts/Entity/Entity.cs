using UnityEngine;
using System;

public class Entity : MonoBehaviour
{
    public enum TypeEnum { Unite, Building }

    public RaceEnum Race;
    public TypeEnum Type;
    public Enum ID
    {
        get
        {
            switch(Race)
            {
                case RaceEnum.Human:
                    switch(Type)
                    {
                        case TypeEnum.Unite: return humainUnite;
                        case TypeEnum.Building: return humainBuilding;
                        default: return null;
                    }
                case RaceEnum.Luminen:
                    switch (Type)
                    {
                        case TypeEnum.Unite: return humainUnite;
                        case TypeEnum.Building: return humainBuilding;
                        default: return null;
                    }
                default: return null;
            }
        }
        set
        {
            switch (Race)
            {
                case RaceEnum.Human:
                    switch (Type)
                    {
                        case TypeEnum.Unite:
                            humainUnite = (Humain.Unite) value;
                            break;
                        case TypeEnum.Building:
                            humainBuilding = (Humain.Building) value;
                            break;
                    }
                    break;
            }
        }
    }

    [SerializeField]
    Humain.Building humainBuilding;
    [SerializeField]
    Humain.Unite humainUnite;

    public  bool IsSameEntity(Entity entity)
    {
        bool result = false;
        if(Race == entity.Race && Type == entity.Type)
        {
            switch(Race)
            {
                case RaceEnum.Human:
                    switch(Type)
                    {
                        case TypeEnum.Building:
                            result = humainBuilding == (Humain.Building) entity.ID;
                            break;
                        case TypeEnum.Unite:
                            result = humainUnite == (Humain.Unite)entity.ID;
                            break;
                    }
                    break;
                case RaceEnum.Luminen:
                    break;
            }
        }
        return result;
    }
}
