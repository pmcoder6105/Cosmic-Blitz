using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E3Control : MonoBehaviour
{
    [SerializeField] ParticleSystem leftLazers;
    [SerializeField] ParticleSystem rightLazers;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > 2)
        {
            leftLazers.Stop();
            rightLazers.Stop();
        }
        if (Time.time > 4.5)
        {
            leftLazers.Play();
            rightLazers.Play();
        }
        if (Time.time > 5.5)
        {
            leftLazers.Stop();
            rightLazers.Stop();
        }
    }
}
