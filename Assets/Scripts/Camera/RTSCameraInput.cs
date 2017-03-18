using UnityEngine;

public class RTSCameraInput : MonoBehaviour
{
    RTSCamera rtsCamera;
    DisplacementZones displacementZones;
    enum VerticalDisplacementEnum { NONE, TOP, BOT}
    VerticalDisplacementEnum VerticalDisplacement;
    enum HorizontalDisplacementEnum { NONE, RIGHT, LEFT}
    HorizontalDisplacementEnum HorizontalDisplacement;
    enum ZoomEnum { ZOOM, DEZOOM, NONE}
    ZoomEnum Zoom;
    enum RotationEnum { NONE, LEFT, RIGHT}
    RotationEnum Rotation;

    void Awake()
    {
        rtsCamera = GetComponent<RTSCamera>();
        displacementZones = FindObjectOfType<DisplacementZones>();
    }

    void LateUpdate()
    {
        ReadKeyboardInput();
        ReadMouseInput();
        Command();
    }

    void ReadMouseInput()
    {
        float zoom = Input.GetAxis("Zoom");
        if (zoom == 0) Zoom = ZoomEnum.NONE;
        else if (zoom > 0) Zoom = ZoomEnum.ZOOM;
        else Zoom = ZoomEnum.DEZOOM;

        if(displacementZones.HorizontalDisplacement != DisplacementZones.HorizontalDisplacementEnum.NONE)
        {
            HorizontalDisplacement = (HorizontalDisplacementEnum)displacementZones.HorizontalDisplacement;
        }
        if(displacementZones.VerticalDisplacement != DisplacementZones.VerticalDisplacementEnum.NONE)
        {
            VerticalDisplacement = (VerticalDisplacementEnum)displacementZones.VerticalDisplacement;
        }
    }
    void ReadKeyboardInput()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        float rotation = Input.GetAxis("Rotation");

        if (horizontal == 0) HorizontalDisplacement = HorizontalDisplacementEnum.NONE;
        else if (horizontal > 0) HorizontalDisplacement = HorizontalDisplacementEnum.RIGHT;
        else HorizontalDisplacement = HorizontalDisplacementEnum.LEFT;

        if (vertical == 0) VerticalDisplacement = VerticalDisplacementEnum.NONE;
        else if (vertical > 0) VerticalDisplacement = VerticalDisplacementEnum.TOP;
        else VerticalDisplacement = VerticalDisplacementEnum.BOT;

        if (rotation == 0) Rotation = RotationEnum.NONE;
        else if (rotation > 0) Rotation = RotationEnum.RIGHT;
        else Rotation = RotationEnum.LEFT;
    }
    void Command()
    {
        switch(HorizontalDisplacement)
        {
            case HorizontalDisplacementEnum.LEFT: rtsCamera.MoveToLeft(); break;
            case HorizontalDisplacementEnum.RIGHT: rtsCamera.MoveToRight(); break;
        }
        switch(VerticalDisplacement)
        {
            case VerticalDisplacementEnum.BOT: rtsCamera.MoveToBottom(); break;
            case VerticalDisplacementEnum.TOP: rtsCamera.MoveToTop(); break;
        }
        switch(Zoom)
        {
            case ZoomEnum.DEZOOM: rtsCamera.DeZoom(); break;
            case ZoomEnum.ZOOM: rtsCamera.Zoom(); break;
        }
        switch(Rotation)
        {
            case RotationEnum.LEFT: rtsCamera.RotateToLeft(); break;
            case RotationEnum.RIGHT: rtsCamera.RotateToRight(); break;
        }
    }
}
