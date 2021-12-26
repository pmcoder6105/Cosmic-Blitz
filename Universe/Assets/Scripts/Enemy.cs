using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int hitPoints = 4;
    [SerializeField] ParticleSystem explosion;
    [SerializeField] ParticleSystem explosionPlayer;
    [SerializeField] ParticleSystem hitSpark;
    [SerializeField] ParticleSystem leftLazer1;
    [SerializeField] ParticleSystem rightLazer1;
    [SerializeField] ParticleSystem leftLazer2;
    [SerializeField] ParticleSystem rightLazer2;
    [SerializeField] ParticleSystem e6Sparks;
    [SerializeField] ParticleSystem e11v1Thruster, e11v2Thruster, e11v3Thruster, e11v4Thruster;
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
                if (leftLazer1 && rightLazer1 != null)
                {
                    Destroy(leftLazer1);
                    Destroy(rightLazer1);
                }
                if (leftLazer2 && rightLazer2 != null)
                {
                    Destroy(leftLazer2);
                    Destroy(rightLazer2);
                }
                if (!explosion.isPlaying)
                {
                    explosion.Play();
                }
                Invoke(nameof(DestroyWhenDestroyed), 2f);
                if (e6Sparks != null)
                {
                    e6Sparks.Stop();
                }
                if (e11v1Thruster != null)
                {
                    e11v1Thruster.Stop();
                }
                if (e11v2Thruster != null)
                {
                    e11v2Thruster.Stop();
                }
                if (e11v3Thruster != null)
                {
                    e11v3Thruster.Stop();
                }
                if (e11v4Thruster != null)
                {
                    e11v4Thruster.Stop();
                }
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
