using UnityEngine;

public class CursorSettings : MonoBehaviour
{
    void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
}
