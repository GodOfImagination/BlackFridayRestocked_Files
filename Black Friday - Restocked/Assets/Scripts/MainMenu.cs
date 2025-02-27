using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public GameObject ScreenMenu;
    public GameObject ScreenControls;
    private void Start()
    {
        ScreenControls.SetActive(false);
    }

    public void SceneLoader(int Number)
    {
        SceneManager.LoadScene(Number);
    }

    public void ButtonControls()
    {
        ScreenMenu.SetActive(false);
        ScreenControls.SetActive(true);
    }
    public void ButtonBack()
    {
        ScreenMenu.SetActive(true);
        ScreenControls.SetActive(false);
    }

    public void ButtonQuit()
    {
        Application.Quit();
    }
}
