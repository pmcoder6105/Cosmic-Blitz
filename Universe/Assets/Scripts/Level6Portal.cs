using UnityEngine.SceneManagement;
using UnityEngine;


public class Level6Portal : MonoBehaviour
{
    Player player;
    [SerializeField] GameObject finishLevel6Timeline;
    [SerializeField] GameObject finishText1, finishText2;
     
    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<BoxCollider>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        SeeIfWarpPortalIsActive();
    }

    void OnCollisionEnter(Collision collision)
    {
        Invoke(nameof(LoadFinishScene), 3f);
        finishLevel6Timeline.SetActive(true);
        player.transform.position = new Vector3(-81.45f, 0.5f, 213.9f);
    }

    void LoadFinishScene()
    {
        SceneManager.LoadScene(8);
    }

    void TurnOffColliderWhenWarping()
    {
        GetComponent<BoxCollider>().enabled = false;
    }

    void DestroyPlayerWhenTimeRunsOut()
    {
        player.ParticleCrashSequence();
    }

    void SeeIfWarpPortalIsActive()
    {
        if (player.enemyShip1 == null)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<BoxCollider>().enabled = true;
            Invoke(nameof(TurnOffColliderWhenWarping), 0.5f);
            Invoke(nameof(DestroyPlayerWhenTimeRunsOut), 30);
            finishText1.SetActive(true);
            finishText2.SetActive(true);
        }
    }
}
