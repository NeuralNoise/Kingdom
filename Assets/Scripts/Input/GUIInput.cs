using UnityEngine;

public class GUIInput : MonoBehaviour
{
    [SerializeField]
    GameObject InGameMenuPrefab;

	void Update ()
    {
		if(Input.GetKeyDown(KeyCode.Escape))
        {
            OpenInGameMenu();
        }
	}

    void OpenInGameMenu()
    {
        InGameMenu InGameMenu = FindObjectOfType<InGameMenu>();
        if(InGameMenu == null)
        {
            RectTransform menu = Instantiate(InGameMenuPrefab, transform).GetComponent<RectTransform>();
            menu.localPosition = Vector3.zero;
        }
        else
        {
            Destroy(InGameMenu.gameObject);
        }
    }
}
