using UnityEngine;

public class DisplacementZones : MonoBehaviour
{
    public enum VerticalDisplacementEnum { NONE, TOP, BOT }
    public VerticalDisplacementEnum VerticalDisplacement;
    public enum HorizontalDisplacementEnum { NONE, RIGHT, LEFT }
    public HorizontalDisplacementEnum HorizontalDisplacement;

    public void OnLeftEnter()
    {
        HorizontalDisplacement = HorizontalDisplacementEnum.LEFT;
    }
    public void OnLeftExit()
    {
        HorizontalDisplacement = HorizontalDisplacementEnum.NONE;
    }
    public void OnRightEnter()
    {
        HorizontalDisplacement = HorizontalDisplacementEnum.RIGHT;
    }
    public void OnRightExit()
    {
        HorizontalDisplacement = HorizontalDisplacementEnum.NONE;
    }
    public void OnTopEnter()
    {
        VerticalDisplacement = VerticalDisplacementEnum.TOP;
    }
    public void OnTopExit()
    {
        VerticalDisplacement = VerticalDisplacementEnum.NONE;
    }
    public void OnBottomEnter()
    {
        VerticalDisplacement = VerticalDisplacementEnum.BOT;
    }
    public void OnBottomExit()
    {
        VerticalDisplacement = VerticalDisplacementEnum.NONE;
    }
}
