using UnityEngine;
using UnityEngine.SceneManagement;

public class InGameMenu : MonoBehaviour
{
    public void Options()
    {

    }
    public void Quit()
    {
        SceneManager.LoadScene("Main menu");
    }
    public void Cancel()
    {
        Destroy(gameObject);
    }
    void Awake()
    {
        Time.timeScale = 0;
    }
    void OnDestroy()
    {
        Time.timeScale = 1;
    }
}
