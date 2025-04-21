using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Manager_Score : MonoBehaviour
{
    [Header("Text"), Space(10)]
    public TMP_Text Text_Items;   // Text from the Conclusion Screen.
    public TMP_Text Text_Price;   // Text from the Conclusion Screen.

    [Space(20)]

    [Header("Score"), Space(10)]
    public int Total_Items = 0;   // Keep track of how many Items the Player has collected.
    public int Total_Price = 0;   // Keep track of how much money the Player has spent.

    public void SceneLoader(int Number)
    {
        SceneManager.LoadScene(Number);
    }

    public void TotalScore()
    {
        Text_Items.text = Total_Items.ToString();
        Text_Price.text = "$" + Total_Price.ToString() + ".00";
    }

    public void ItemCollected(int ItemPrice)
    {
        Total_Items += 1;
        Total_Price += ItemPrice;
    }
}
