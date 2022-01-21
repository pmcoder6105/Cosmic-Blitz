using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    [Header("References")]
    [Tooltip("Get the component TMP_Text")] TMP_Text score;

    [Header("The variables")]
    [Tooltip("This is the score")] public int scoreAmount;

    //Cache our references && Make sure the score is 0
    void Start()
    {
        score = GetComponent<TMP_Text>();
        score.text = "0";
    }

    //Increase the score by the amount to increase
    //Then display the score to the text on screen
    public void IncreaseScore(int amountToIncreaseScore)
    {
        scoreAmount = amountToIncreaseScore + scoreAmount;
        score.text = scoreAmount.ToString();
    }
}
