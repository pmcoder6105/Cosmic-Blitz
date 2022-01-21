using UnityEngine.SceneManagement;
using UnityEngine;

public class TravelToPlanet : MonoBehaviour
{
    [Header("These are all the tunables")]
    [Tooltip("Amount to translate when traveling")] [SerializeField] float verticalControlSpeed = 50;
    
    [Header("References")]
    [Tooltip("Player reference")] Player p;

    //Set Time to 0, set player component to false, && cache our reference
    void Start()
    {
        Time.timeScale = 0;
        GetComponent<Player>().enabled = false;
        p = FindObjectOfType<Player>();
    }

    //Translate forward at a frame rate independant rate and after 10 secs, load the next scene, which is scene #7
    //Also make sure that StopLazersIfOnTravelToPlanet() is working 
    void Update()
    {
        transform.Translate(0, 0, .2f * Time.deltaTime * verticalControlSpeed);
        if (Time.timeSinceLevelLoad > 10)
        {
            SceneManager.LoadScene(7);
        }
        StopLazersIfOnTravelToPlanet();
    }

    //If the player is on the sixth scene, which is the travel to the planet scene
    //Then destroy the lazer generator child of the player ship
    void StopLazersIfOnTravelToPlanet()
    {
        int travelToPlanetScene = SceneManager.GetActiveScene().buildIndex;
        if (travelToPlanetScene == 6)
        {
            Destroy(p.lazerGenerator);
        }
    }
}
