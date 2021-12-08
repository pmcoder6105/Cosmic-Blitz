using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] int hitPoints = 4;

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
            if (hitPoints < 1)
            {
                Destroy(gameObject);
            }
            
            
        }
    }
}
