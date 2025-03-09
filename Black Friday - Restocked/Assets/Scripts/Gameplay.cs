using UnityEngine;
using System.Collections;
using TMPro;

public class Gameplay : MonoBehaviour
{
    [Header("Screens"), Space(10)]
    public GameObject ScreenReady;        // Screen that appears when the game starts.
    public GameObject ScreenGameplay;     // Screen that appears when the game is running.
    public GameObject ScreenConclusion;   // Screen that appears when the game ends.

    [Space(20)]

    [Header("Text"), Space(10)]
    public TMP_Text TextReady;            // Text from the Ready Screen.
    public GameObject TextHint;           // Text from the Ready Screen.
    public TMP_Text TextTimer;            // Text from the Gameplay Screen.


    private float CountdownReady = 3;     // Number for how long the Ready Screen lasts.
    private float CountdownTimer = 120;   // Number for how long the Timer lasts. | 300 Seconds = 5 Minutes.

    private bool PlayerReady = false;     // Used to determine whether or not the Player has hit the Spacebar.
    private bool GameRunning = false;     // Used to determine whether or not the Game is currently running.

    private void Start()
    {
        ScreenGameplay.SetActive(false);
        ScreenConclusion.SetActive(false);

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            TextHint.SetActive(false);
            StartCoroutine(DelayStart());
        }

        if (PlayerReady)
        {
            if (CountdownReady > 0)
            {
                CountdownReady -= Time.deltaTime;
                TextReady.text = CountdownReady.ToString("N0");
            }
            else
            {
                CountdownReady = 0;
                TextReady.text = "GO!";
                StartCoroutine(DelayRemoval());
                ScreenGameplay.SetActive(true);
                GameRunning = true;
                GameObject.Find("Player").GetComponent<PlayerController>().enabled = true;
            }
        }

        if (GameRunning)
        {
            if (CountdownTimer > 0)
            {
                CountdownTimer -= Time.deltaTime;
                DisplayTime(CountdownTimer);
            }
            else
            {
                CountdownTimer = 0;
                ScreenConclusion.SetActive(true);

                Cursor.lockState = CursorLockMode.Confined;
                Cursor.visible = true;
            }
        }
    }

    private void DisplayTime(float TimeToDisplay)
    {
        float Minutes = Mathf.FloorToInt(TimeToDisplay / 60);
        float Seconds = Mathf.FloorToInt(TimeToDisplay % 60);
        TextTimer.text = $"{Minutes:00}:{Seconds:00}";
    }

    IEnumerator DelayStart()
    {
        yield return new WaitForSeconds(1);
        PlayerReady = true;
    }

    IEnumerator DelayRemoval()
    {
        yield return new WaitForSeconds(1);
        ScreenReady.SetActive(false);
    }
}
