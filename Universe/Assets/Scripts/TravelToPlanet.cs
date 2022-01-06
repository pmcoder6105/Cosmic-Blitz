using UnityEngine.SceneManagement;
using UnityEngine;

public class TravelToPlanet : MonoBehaviour
{
    float verticalControlSpeed = 50;


    void Start()
    {
        Time.timeScale = 0;
        GetComponent<Player>().enabled = false;
    }

    void Update()
    {
        transform.Translate(0, 0, .2f * Time.deltaTime * verticalControlSpeed);
        if (Time.timeSinceLevelLoad > 20)
        {
            SceneManager.LoadScene(7);
        }
    }
}
