using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    [SerializeField] ParticleSystem leftLazer;
    [SerializeField] ParticleSystem rightLazer;
    [SerializeField] ParticleSystem explosion;
    [SerializeField] ParticleSystem thruster;
    [SerializeField] ParticleSystem hitSpark;
    [SerializeField] int healthPoints = 8;
    [SerializeField] GameObject Heart1;
    [SerializeField] GameObject Heart2;
    [SerializeField] GameObject Heart3;
    [SerializeField] GameObject Heart4;
    [SerializeField] GameObject DeadHeart1;
    [SerializeField] GameObject DeadHeart2;
    [SerializeField] GameObject DeadHeart3;
    [SerializeField] GameObject DeadHeart4;
    [SerializeField] float controlSpeed = 75;
    [SerializeField] Material heartStopColor;


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ProcessShip();
        DebugKeys();
    }

    void DebugKeys()
    {
        if (Input.GetKey(KeyCode.C))
        {
            GetComponent<BoxCollider>().enabled = false;
        }
        if (Input.GetKey(KeyCode.L))
        {
            LoadNextScene();
        }
    }
    
    void ProcessShip()
    {
        if (Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.Mouse0))
        {
            leftLazer.Play();
            rightLazer.Play();
        }

        if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.Mouse0))
        {
            leftLazer.Stop();
            rightLazer.Stop();
        }
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-.2f * Time.deltaTime * controlSpeed, 0, 0);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(.2f * Time.deltaTime * controlSpeed, 0, 0);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        hitSpark.Play();
        healthPoints = healthPoints - 1;
        if (healthPoints == 7)
        {
            Heart4.GetComponent<Animator>().enabled = false;
            Heart4.GetComponent<SpriteRenderer>().enabled = false;
        }
        if (healthPoints == 6)
        {
            Destroy(DeadHeart4);
            Destroy(Heart4);
        }
        if (healthPoints == 5)
        {
            Heart3.GetComponent<Animator>().enabled = false;
            Heart3.GetComponent<SpriteRenderer>().enabled = false;
        }
        if (healthPoints == 4)
        {
            Destroy(DeadHeart3);
            Destroy(Heart3);
        }
        if (healthPoints == 3)
        {
            Heart2.GetComponent<Animator>().enabled = false;
            Heart2.GetComponent<SpriteRenderer>().enabled = false;
        }
        if (healthPoints == 2)
        {
            Destroy(DeadHeart2);
            Destroy(Heart2);
        }
        if (healthPoints == 1)
        {
            Heart1.GetComponent<Animator>().enabled = false;
            Heart1.GetComponent<SpriteRenderer>().enabled = false;
        }
        if (healthPoints == 0)
        {
            ParticleCrashSequence();
            Destroy(DeadHeart1);
            Destroy(Heart1);
        }

    }

    public void ParticleCrashSequence()
    {
        GetComponent<MeshRenderer>().enabled = false;
        GetComponent<Player>().enabled = false;
        Invoke(nameof(LoadCurrentScene), 2f);
        thruster.Stop();
        if (!explosion.isPlaying)
        {
            explosion.Play();
        }
    }

    void OnParticleCollision(GameObject other)
    {        
        if (other.gameObject.tag == "Enemy")
        {
            hitSpark.Play();
            healthPoints = healthPoints - 1;
            if (healthPoints == 7)
            {
                Heart4.GetComponent<Animator>().enabled = false;
                Heart4.GetComponent<SpriteRenderer>().enabled = false;
            }
            if (healthPoints == 6)
            {
                Destroy(DeadHeart4);
                Destroy(Heart4);
            }
            if (healthPoints == 5)
            {
                Heart3.GetComponent<Animator>().enabled = false;
                Heart3.GetComponent<SpriteRenderer>().enabled = false;
            }
            if (healthPoints == 4)
            {
                Destroy(DeadHeart3);
                Destroy(Heart3);
            }
            if (healthPoints == 3)
            {
                Heart2.GetComponent<Animator>().enabled = false;
                Heart2.GetComponent<SpriteRenderer>().enabled = false;
            }
            if (healthPoints == 2)
            {
                Destroy(DeadHeart2);
                Destroy(Heart2);
            }
            if (healthPoints == 1)
            {
                Heart1.GetComponent<Animator>().enabled = false;
                Heart1.GetComponent<SpriteRenderer>().enabled = false;
            }
            if (healthPoints == 0)
            {
                CollisionCrashSequence();
                Destroy(DeadHeart1);
                Destroy(Heart1);
            }
        }
    }

    private void CollisionCrashSequence()
    {
        GetComponent<Player>().enabled = false;
        Invoke(nameof(LoadCurrentScene), 2f);
        GetComponent<MeshRenderer>().enabled = false;
        thruster.Stop();
        if (!explosion.isPlaying)
        {
            explosion.Play();
        }
        leftLazer.Stop();
        rightLazer.Stop();
    }

    public void LoadCurrentScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    void LoadNextScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        SceneManager.LoadScene(nextSceneIndex);
    }
    
    public void DestroyWhenEnemyFinishes()
    {
        GetComponent<BoxCollider>().enabled = false;
        GetComponent<Player>().enabled = false;
        GetComponent<MeshRenderer>().enabled = false;
        leftLazer.Stop();
        rightLazer.Stop();
        Destroy(Heart1);
        Destroy(Heart2);
        Destroy(Heart3);
        Destroy(Heart4);
        thruster.Stop();
    }
}
