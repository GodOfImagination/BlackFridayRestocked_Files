using UnityEngine;

public class Manager_Score : MonoBehaviour
{
    public float CollectedItems = 0;
    public float TotalPrice = 0;

    private void Start()
    {
        
    }

    private void Update()
    {
        
    }
    public void ItemCollected(float ItemPrice)
    {
        CollectedItems += 1;
        TotalPrice += ItemPrice;
    }
}
