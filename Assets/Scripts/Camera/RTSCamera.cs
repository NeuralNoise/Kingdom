using UnityEngine;

public class RTSCamera : MonoBehaviour
{
    #region Properties
    [SerializeField]
    private int m_displacementSpeed;
    public int DisplacementSpeed
    {
        get { return m_displacementSpeed; }
        set { m_displacementSpeed = value; }
    }
    [SerializeField]
    private int m_rotationSpeed;
    public int RotationSpeed
    {
        get { return m_rotationSpeed; }
        set { m_rotationSpeed = value; }
    }
    [SerializeField]
    private int m_zoomSpeed;
    public int ZoomSpeed
    {
        get { return m_zoomSpeed; }
        set { m_zoomSpeed = value; }
    }
    [SerializeField]
    private int m_minDistance;
    public int MinDistance
    {
        get { return m_minDistance; }
        set { m_minDistance = value; }
    }
    [SerializeField]
    private int m_maxDistance;
    public int MaxDistance
    {
        get { return m_maxDistance; }
        set { m_maxDistance = value; }
    }
    [SerializeField]
    private bool m_displacementLocked;
    public bool DisplacementLocked
    {
        get { return m_displacementLocked; }
        set { m_displacementLocked = value; }
    }
    private bool m_rotationLocked;
    public bool RotationLocked
    {
        get { return m_rotationLocked; }
        set { m_rotationLocked = value; }
    }

    private LayerMask m_layerMask;
    #endregion

    #region Public Methods
    public void MoveToLeft()
    {
        Move(-GetDisplacementLenght() * transform.right);
    }
    public void MoveToRight()
    {
        Move(GetDisplacementLenght() * transform.right);
    }
    public void MoveToTop()
    {
        Move(GetDisplacementLenght() * new Vector3(transform.forward.x, 0, transform.forward.z).normalized);
    }
    public void MoveToBottom()
    {
        Move( - GetDisplacementLenght() * new Vector3(transform.forward.x, 0, transform.forward.z).normalized);
    }
    public void RotateToRight()
    {
        if(!RotationLocked)
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, 100.0f, m_layerMask, QueryTriggerInteraction.Collide))
            {
                transform.RotateAround(hitInfo.point, Vector3.up, m_rotationSpeed * Time.deltaTime);
            }
        }
    }
    public void RotateToLeft()
    {
        if(!RotationLocked)
        {
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, 100.0f, m_layerMask, QueryTriggerInteraction.Collide))
            {
                transform.RotateAround(hitInfo.point, Vector3.up, -m_rotationSpeed * Time.deltaTime);
            }
        }
    }
    public void Zoom()
    {
        transform.position += m_zoomSpeed * Time.deltaTime * transform.forward;
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 100.0f, m_layerMask, QueryTriggerInteraction.Collide))
        {
            if (hitInfo.distance < MinDistance - float.Epsilon)
            {
                transform.position = hitInfo.point - MinDistance * transform.forward;
            }
        }
    }
    public void DeZoom()
    {
        transform.position -= m_zoomSpeed * Time.deltaTime * transform.forward;
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 100.0f, m_layerMask, QueryTriggerInteraction.Collide))
        {
            if (hitInfo.distance > MaxDistance + float.Epsilon)
            {
                transform.position = hitInfo.point - MaxDistance * transform.forward;
            }
        }
    }
    #endregion

    #region Private Methods
    void Awake()
    {
        m_layerMask = 1 << LayerMask.NameToLayer("Map");
    }
    float GetDisplacementLenght()
    {
        float result = 0.0f;
        Ray ray = new Ray(transform.position, transform.forward);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, 100.0f, m_layerMask, QueryTriggerInteraction.Collide))
        {
            result = ((hitInfo.distance - m_minDistance) + m_displacementSpeed) * Time.deltaTime;
        }
        return result;
    } 
    void Move(Vector3 displacement)
    {
        if(!DisplacementLocked)
        {
            Vector3 newPosition = transform.position + displacement;
            Ray ray = new Ray(newPosition, transform.forward);
            RaycastHit hitInfo;
            if (Physics.Raycast(ray, out hitInfo, 100.0f, m_layerMask, QueryTriggerInteraction.Collide))
            {
                transform.position = newPosition;
            }
        }
    }
    #endregion
}