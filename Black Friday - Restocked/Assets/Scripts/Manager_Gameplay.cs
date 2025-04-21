using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager_Gameplay : MonoBehaviour
{
    [Header("Screens"), Space(10)]
    public GameObject Screen_Ready;                            // Screen that appears when the game starts.
    public GameObject Screen_Gameplay;                         // Screen that appears when the game is running.
    public GameObject Screen_Conclusion;                       // Screen that appears when the game ends.

    [Space(20)]

    [Header("Text"), Space(10)]
    public TMP_Text Text_Ready;                                // Text from the Ready Screen.
    public GameObject TextObject_Hint;                         // Text from the Ready Screen.
    public TMP_Text Text_Timer;                                // Text from the Gameplay Screen.
    public List<TMP_Text> Text_Items = new List<TMP_Text>();   // Text from the Shopping List.

    private float Countdown_Ready = 3;                         // Number for how long the Ready Screen lasts.
    private float Countdown_Timer = 20;                       // Number for how long the Timer lasts. | 300 Seconds = 5 Minutes.

    private bool Is_PlayerReady = false;                       // Used to determine whether or not the Player has hit the Spacebar.
    private bool Is_GameRunning = false;                       // Used to determine whether or not the Game is currently running.

    private Manager_Score Manager_Score;                       // Used to determine what the Final Score is.

    private void Start()
    {
        Screen_Gameplay.SetActive(false);
        Screen_Conclusion.SetActive(false);

        Manager_Score = FindFirstObjectByType<Manager_Score>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            TextObject_Hint.SetActive(false);
            StartCoroutine(DelayStart());
        }

        if (Is_PlayerReady)
        {
            if (Countdown_Ready > 0)
            {
                Countdown_Ready -= Time.deltaTime;
                Text_Ready.text = Countdown_Ready.ToString("N0");
            }
            else
            {
                Countdown_Ready = 0;
                Text_Ready.text = "GO!";
                StartCoroutine(DelayRemoval());
                Screen_Gameplay.SetActive(true);
                Is_GameRunning = true;
                GameObject.Find("Player").GetComponent<Player_Behavior>().enabled = true;
            }
        }

        if (Is_GameRunning)
        {
            if (Countdown_Timer > 0)
            {
                Countdown_Timer -= Time.deltaTime;
                DisplayTime(Countdown_Timer);
            }
            else
            {
                Countdown_Timer = 0;
                Screen_Conclusion.SetActive(true);

                Manager_Score.TotalScore();

                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
                GameObject.Find("Player").GetComponent<Player_Behavior>().enabled = false;
            }
        }
    }

    private void DisplayTime(float TimeToDisplay)
    {
        float Minutes = Mathf.FloorToInt(TimeToDisplay / 60);
        float Seconds = Mathf.FloorToInt(TimeToDisplay % 60);
        Text_Timer.text = $"{Minutes:00}:{Seconds:00}";
    }

    IEnumerator DelayStart()
    {
        yield return new WaitForSeconds(1);
        Is_PlayerReady = true;
    }

    IEnumerator DelayRemoval()
    {
        yield return new WaitForSeconds(1);
        Screen_Ready.SetActive(false);
    }
}
