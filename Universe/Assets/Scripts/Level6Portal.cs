using UnityEngine.SceneManagement;
using UnityEngine;


public class Level6Portal : MonoBehaviour
{
    Player player;
    [SerializeField] GameObject finishLevel6Text;
    [SerializeField] GameObject finishLevel6Timeline;
    
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
        if (player.enemyShip1 == null)
        {
            GetComponent<SpriteRenderer>().enabled = true;
            GetComponent<BoxCollider>().enabled = true;
            finishLevel6Text.SetActive(true); 
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        Invoke(nameof(LoadFinishScene), 3f);
        finishLevel6Timeline.SetActive(true);
    }

    void LoadFinishScene()
    {
        SceneManager.LoadScene(8);
    }
}
