using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager_MainMenu : MonoBehaviour
{
    [Header("Screens"), Space(10)]
    public GameObject Screen_Menu;
    public GameObject Screen_HowToPlay;

    private void Start()
    {
        Screen_HowToPlay.SetActive(false);
    }

    public void SceneLoader(int Number)
    {
        SceneManager.LoadScene(Number);
    }

    public void Button_HowToPlay()
    {
        Screen_Menu.SetActive(false);
        Screen_HowToPlay.SetActive(true);
    }
    public void Button_Back()
    {
        Screen_Menu.SetActive(true);
        Screen_HowToPlay.SetActive(false);
    }

    public void Button_Quit()
    {
        Application.Quit();
    }
}
