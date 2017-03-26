using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void Solo()
    {
        SceneManager.LoadScene("Solo Menu");
    }

    public void Multi()
    {

    }

    public void Options()
    {

    }

    public void Quit()
    {
        Application.Quit();
    }
}