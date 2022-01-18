using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusLevelEnemy : MonoBehaviour
{
    [SerializeField] int hitPoints = 4;
    
    [Header("All the visuals for the enemy ship")]
    [Tooltip("This is the explosion")] [SerializeField] ParticleSystem explosion;
    [Tooltip("This is the explosion vfx for the player ship when the enemy crosses into the home planet")] [SerializeField] ParticleSystem explosionPlayer;
    [Tooltip("This is the spark that goes off when it takes damage")] [SerializeField] ParticleSystem hitSpark;
    [Tooltip("This is the enemy thruster")] [SerializeField] ParticleSystem thruster;

    [Header("GameObjects")]
    [SerializeField] GameObject passOverObject;
    
    
    [Header("All of the references")]
    [Tooltip("This is the player reference")] Player player;
    [Tooltip("This is the audiosource reference")] AudioSource aS;


    [Header("AudioClips")]
    [Tooltip("This is the destruction sfx")] [SerializeField] AudioClip destruction;

    //Make sure to cache our references
    void Start()
    {
        player = FindObjectOfType<Player>();
        aS = GetComponent<AudioSource>();
    }

    void Update()
    {
        transform.Translate(0, 0, 0.1f * Time.deltaTime * 30);
        if (hitSpark == null)
        {
            return;
        }
        if (explosionPlayer == null)
        {
            return;
        }
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
                GetComponent<BonusLevelEnemy>().enabled = false;
                GetComponent<BoxCollider>().enabled = false;
                if (!explosion.isPlaying)
                {
                    explosion.Play();
                }
                Invoke(nameof(DestroyWhenDestroyed), 2f);
                if (thruster != null)
                {
                    thruster.Stop();
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
        if (other.gameObject.tag == "Player")
        {
            player.CollisionCrashSequence();
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
