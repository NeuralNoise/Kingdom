using UnityEngine.SceneManagement;
using UnityEngine;

public class SoloMenu : MonoBehaviour
{
    public void Campaign()
    {

    }

    public void Cancel()
    {
        SceneManager.LoadScene("Main Menu");
    }
}
