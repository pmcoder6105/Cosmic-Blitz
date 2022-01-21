using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BonusTimer : MonoBehaviour
{
    [Header("References")]
    [Tooltip("Get the component TMP_Text")] TMP_Text timer;

    //Cache references
    void Start()
    {
        timer = GetComponent<TMP_Text>();
    }

    //Make sure that timer text is displaying the time
    void Update()
    {
        string timeSinceLevelLoaded = Time.timeSinceLevelLoad.ToString();
        timer.text = timeSinceLevelLoaded;
    }

    //When this method is called, we will change the timer text to "Finished!"
    public void ChangeTextToDone()
    {
        timer.text = "Finished!";
    }
}
