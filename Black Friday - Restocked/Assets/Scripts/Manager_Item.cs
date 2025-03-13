using UnityEngine;

public class Manager_Item : MonoBehaviour
{
    public int ItemPrice;
    
    private Manager_Score ScoreManager;
    private bool InRange = false;

    private void Start()
    {
        ScoreManager = GetComponent<Manager_Score>();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && InRange)
        {
            ScoreManager.ItemCollected(ItemPrice);
        }
    }

    private void OnTriggerEnter(Collider Other)
    {
        if (Other.tag == "Player")
        {
            InRange = true;
        }
    }

    private void OnTriggerExit(Collider Other)
    {
        if (Other.tag == "Player")
        {
            InRange = false;
        }
    }
}
