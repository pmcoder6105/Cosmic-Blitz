using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class BonusTextScript : MonoBehaviour
{
    TMP_Text timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = GetComponent<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        string timeSinceLevelLoaded = Time.timeSinceLevelLoad.ToString();
        timer.text = timeSinceLevelLoaded;
    }
}
