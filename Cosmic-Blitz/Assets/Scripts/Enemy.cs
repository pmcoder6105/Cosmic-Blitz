using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Header("All the tunables for the enemy")]
    [Tooltip("This is how many hits the enemy ship can take")] [SerializeField] int hitPoints = 4;
    
    [Header("All the visuals for the enemy ship")]
    [Tooltip("This is the explosion")] [SerializeField] ParticleSystem explosion;
    [Tooltip("This is the explosion vfx for the player ship when the enemy crosses into the home planet")] [SerializeField] ParticleSystem explosionPlayer;
    [Tooltip("This is the spark that goes off when it takes damage")] [SerializeField] ParticleSystem hitSpark;
    [Tooltip("This is the first laser")] [SerializeField] ParticleSystem leftLazer1;
    [Tooltip("This is the second laser")] [SerializeField] ParticleSystem rightLazer1;
    [Tooltip("This is the third laser")] [SerializeField] ParticleSystem leftLazer2;
    [Tooltip("This is the fourth laser")] [SerializeField] ParticleSystem rightLazer2;
    [Tooltip("This is the enemy thruster")] [SerializeField] ParticleSystem thruster;
    [Tooltip("These are specific thrusters for some of the enemy ships")] [SerializeField] ParticleSystem e11v1Thruster, e11v2Thruster, e11v3Thruster, e11v4Thruster;
    
    
    [Header("All of the references")]
    [Tooltip("This is the player reference")] Player player;
    [Tooltip("This is the audiosource reference")] AudioSource aS;


    [Tooltip("This is the destruction sfx")] [SerializeField] AudioClip destruction;

    //Make sure to cache our references
    void Start()
    {
        player = FindObjectOfType<Player>();
        aS = GetComponent<AudioSource>();
    }

    //On particle collision
    void OnParticleCollision(GameObject other)
    {
        //If the particle was a player particle
        //reduce hit points by 1
        //play a vfx
        if (other.gameObject.tag == "Player")
        {
            hitPoints = hitPoints - 1;
            hitSpark.Play();            
            if (hitPoints == 0)
            {
                if (!aS.isPlaying)
                {
                    aS.PlayOneShot(destruction);
                }
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
                if (thruster != null)
                {
                    thruster.Stop();
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

    //What happens on collision
    void OnCollisionEnter(Collision other)
    {
        //If the collider is the enemy finish pad
        //play explosionPlayer vfx
        //Call DestroyWhenEnemyFinishes from the player script
        //Finally, load the current scene in 2 seconds
        if (other.gameObject.tag == "EnemyFinishPad")
        {                        
            explosionPlayer.Play();            
            player.DestroyWhenEnemyFinishes();
            Invoke(nameof(EnemyLoadCurrentScene), 2f);
        }
    }
    
    //Load Current Scene
    void EnemyLoadCurrentScene()
    {
        player.LoadCurrentScene();
    }
    
    //Destroy the gameObject
    void DestroyWhenDestroyed()
    {
        Destroy(gameObject);
    }
}
