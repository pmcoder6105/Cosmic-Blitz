using UnityEngine.SceneManagement;
using UnityEngine;

public class TravelToPlanet : MonoBehaviour
{
    float verticalControlSpeed = 50;
    private void Start()
    {
        
    }

    private void Update()
    {
        transform.Translate(0, 0, .2f * Time.deltaTime * verticalControlSpeed);
        if (Time.timeSinceLevelLoad > 20)
        {
            SceneManager.LoadScene(7);
        }
        GetComponent<Player>().enabled = false;
    }
}
