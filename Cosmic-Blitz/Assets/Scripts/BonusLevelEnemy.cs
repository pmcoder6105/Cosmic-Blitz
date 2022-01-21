using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusLevelEnemy : MonoBehaviour
{
    [SerializeField] int hitPoints = 4;
    
    [Header("All the visuals for the enemy ship")]
    [Tooltip("This is the explosion")] [SerializeField] ParticleSystem explosion;
    [Tooltip("This is the spark that goes off when it takes damage")] [SerializeField] ParticleSystem hitSpark;
    [Tooltip("This is the enemy thruster")] [SerializeField] ParticleSystem thruster;
    [SerializeField] GameObject WinScreen;
    [SerializeField] GameObject LoseScreen;


    [Header("All of the references")]
    [Tooltip("This is the player reference")] Player player;
    [Tooltip("This is the audiosource reference")] AudioSource aS;
    [Tooltip("This is the scorescript reference")] ScoreScript sS;
    [Tooltip("This is the bonustimer script reference")] BonusTimer bT;

    //Make sure to cache our references
    void Start()
    {
        player = FindObjectOfType<Player>();
        aS = GetComponent<AudioSource>();
        sS = FindObjectOfType<ScoreScript>();
        bT = FindObjectOfType<BonusTimer>();
    }

    //Reminder: this script is only for the enemies in the bonus level
    //We want to move the ships on a constant rate toward the player
    //If the time since the level loaded is more or equal to 30
    //We want to make the timer say finished
    //We want to slow down time
    //And call FinishBonus() in .5 seconds
    void Update()
    {
        transform.Translate(0, 0, 0.1f * Time.deltaTime * 30);
        if (Time.timeSinceLevelLoad >= 30)
        {
            bT.ChangeTextToDone();
            Time.timeScale = 0.5f;
            Invoke(nameof(FinishBonus), 0.5f);
        }
    }

    //This method is for checking the score and executing certain things
    void FinishBonus()
    {
        //If the score is greater than or equal to 24000
        //We want to activate the win screen
        //We want to make sure that the enemy can't be damaged by disabling the box collider
        //We want to play the win boost flame
        if (sS.scoreAmount >= 24000f)
        {
            WinScreen.SetActive(true);
            GetComponent<BoxCollider>().enabled = false;
            if (!player.winBoostFlame.isPlaying)
            {
                player.winBoostFlame.Play();
            }
        }

        //If the score is less than or equal to 24000
        //We want to activate the lose screen
        //We want to make sure that the enemy can't be damaged by disabling the box collider
        if (sS.scoreAmount < 24000f)
        {
            LoseScreen.SetActive(true);
            GetComponent<BoxCollider>().enabled = false;
        }
    }

    //On particle collision
    void OnParticleCollision(GameObject other)
    {
        //If the particle was a player lazer particle
        //reduce hit points by 1
        //play a vfx
        //also increase the score by 38
        if (other.gameObject.tag == "Player")
        {
            hitPoints = hitPoints - 1;
            hitSpark.Play();
            sS.IncreaseScore(38);
            if (hitPoints == 0)
            {
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
        //If the enemy collides with the player, instantly destroy the player
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
