using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int hitPoints = 4;
    [SerializeField] ParticleSystem explosion;
    [SerializeField] ParticleSystem explosionPlayer;
    [SerializeField] ParticleSystem hitSpark;
    [SerializeField] ParticleSystem leftLazer;
    [SerializeField] ParticleSystem rightLazer;
    Player player;
    

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<Player>();
    }

    // Update is called once per frame
    void Update()
    {

    }


    public void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == "Player")
        {
            hitPoints = hitPoints - 1;
            hitSpark.Play();            
            if (hitPoints == 0)
            {
                GetComponent<MeshRenderer>().enabled = false;
                GetComponent<Enemy>().enabled = false;
                GetComponent<BoxCollider>().enabled = false;
                GetComponent<Animator>().enabled = false;
                if (leftLazer && rightLazer != null)
                {
                    Destroy(leftLazer);
                    Destroy(rightLazer);
                }
                if (!explosion.isPlaying)
                {
                    explosion.Play();
                }
                Invoke(nameof(DestroyWhenDestroyed), 2f);
            }
        }
    }

    public void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "EnemyFinishPad")
        {                        
            explosionPlayer.Play();            
            player.DestroyWhenEnemyFinishes();
            Invoke(nameof(EnemyLoadCurrentScene), 2f);
        }
    }
    void EnemyLoadCurrentScene()
    {
        player.LoadCurrentScene();
    }
    
    void DestroyWhenDestroyed()
    {
        Destroy(gameObject);
    }
}
