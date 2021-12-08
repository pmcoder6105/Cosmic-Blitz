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

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ProcessMovement();
        ProcessLazers();
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
    
    void ProcessLazers()
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
    }

    void ProcessMovement()
    {
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(-.2f, 0, 0);
        }

        if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(.2f, 0, 0);
        }
    }

    void OnCollisionEnter(Collision collision)
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
    }

    void LoadCurrentScene()
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
}
