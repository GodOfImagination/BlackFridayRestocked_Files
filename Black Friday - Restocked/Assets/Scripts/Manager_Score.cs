using UnityEngine;
using TMPro;

public class Manager_Score : MonoBehaviour
{
    [Header("Text"), Space(10)]
    public TMP_Text TextItems;         // Screen that appears when the game starts.
    public TMP_Text TextPrice;         // Screen that appears when the game is running.

    [Space(20)]

    [Header("Score"), Space(10)]
    public int CollectedItems = 0;   // Keep track of how many Items the Player has collected.
    public int TotalPrice = 0;       // Keep track of how much money the Player has spent.

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
    public void ItemCollected(int ItemPrice)
    {
        CollectedItems += 1;
        TotalPrice += ItemPrice;
    }
}
