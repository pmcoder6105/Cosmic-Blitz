using TMPro;
using UnityEngine;

public class ScoreScript : MonoBehaviour
{
    TMP_Text score;
    int scoreAmount;
    
    // Start is called before the first frame update
    void Start()
    {
        score = GetComponent<TMP_Text>();
        score.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void IncreaseScore(int amountToIncreaseScore)
    {
        scoreAmount = amountToIncreaseScore + scoreAmount;
        score.text = scoreAmount.ToString();
    }
}
