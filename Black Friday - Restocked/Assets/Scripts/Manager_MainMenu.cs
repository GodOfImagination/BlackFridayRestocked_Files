using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager_MainMenu : MonoBehaviour
{
    [Header("Screens"), Space(10)]
    public GameObject ScreenMenu;
    public GameObject ScreenHowToPlay;

    private void Start()
    {
        ScreenHowToPlay.SetActive(false);
    }

    public void SceneLoader(int Number)
    {
        SceneManager.LoadScene(Number);
    }

    public void ButtonHowToPlay()
    {
        ScreenMenu.SetActive(false);
        ScreenHowToPlay.SetActive(true);
    }
    public void ButtonBack()
    {
        ScreenMenu.SetActive(true);
        ScreenHowToPlay.SetActive(false);
    }

    public void ButtonQuit()
    {
        Application.Quit();
    }
}
