using UnityEngine;

public class Manager_Item : MonoBehaviour
{
    public int Price;
    private Manager_Score Manager_Score;
    private bool InRange = false;

    private void Start()
    {
        Manager_Score = FindFirstObjectByType<Manager_Score>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && InRange)
        {
            Manager_Score.ItemCollected(Price);
        }
    }

    private void OnTriggerEnter(Collider Other)
    {
        if (Other.CompareTag("Player"))
        {
            InRange = true;
        }
    }

    private void OnTriggerExit(Collider Other)
    {
        if (Other.CompareTag("Player"))
        {
            InRange = false;
        }
    }
}
