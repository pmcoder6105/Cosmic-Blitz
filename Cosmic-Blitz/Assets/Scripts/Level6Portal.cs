using UnityEngine.SceneManagement;
using UnityEngine;


public class Level6Portal : MonoBehaviour
{
    [Header("Reference")]
    Player player;
    
    [Header("Necessities")]
    [SerializeField] GameObject finishLevel6Timeline;
    [SerializeField] GameObject finishText1, finishText2;
     
    //Cache reference
    //Make sure that portal isn't visible and interactable by turning off sR & bC
    void Start()
    {
        player = FindObjectOfType<Player>();
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
    }

    //Make Sure SeeIfWarpPortalIsActive() is running
    void Update()
    {
        SeeIfWarpPortalIsActive();
    }

    //When you collide with player, load the ending scene in 3 secs
    //Set the new timeline for when player enters the warp
    void OnCollisionEnter(Collision collision)
    {
        Invoke(nameof(LoadFinishScene), 3f);
        finishLevel6Timeline.SetActive(true);
    }

    //Load ending scene
    void LoadFinishScene()
    {
        SceneManager.LoadScene(8);
    }

    //Make sure that player can pass through portal
    void TurnOffColliderWhenWarping()
    {
        GetComponent<BoxCollider>().enabled = false;
    }

    //Destroy player if time runs out
    void DestroyPlayerWhenTimeRunsOut()
    {
        player.CollisionCrashSequence();
    }

    //Make sure portal is visible and interactable
    //Invoke TurnOffColliderWhenWarping() in .5 seconds
    //Call DestroyPlayerWhenTimeRunsOut() in 25 seconds
    //Finally, set both finishing texts active
    void SeeIfWarpPortalIsActive()
    {
        if (player.enemyShip1 == null)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<BoxCollider>().enabled = true;
            Invoke(nameof(TurnOffColliderWhenWarping), 0.5f);
            Invoke(nameof(DestroyPlayerWhenTimeRunsOut), 25);
            finishText1.SetActive(true);
            finishText2.SetActive(true);
        }
    }
}
