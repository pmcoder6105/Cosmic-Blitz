using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int hitPoints = 4;
    [SerializeField] ParticleSystem explosion;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnParticleCollision(GameObject other)
    {
        if (other.gameObject.tag == "Player")
        {
            hitPoints = hitPoints - 1;
            if (hitPoints == 0)
            {
                GetComponent<MeshRenderer>().enabled = false;
                GetComponent<Enemy>().enabled = false;
                GetComponent<BoxCollider>().enabled = false;
                GetComponent<Animator>().enabled = false;
                explosion.Play();
            }
        }
    }
}
