using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewWaveSpawner : MonoBehaviour
{
    [SerializeField] GameObject wave;
    [SerializeField] GameObject spawner;
    
    // Start is called before the first frame update
    void Start()
    {
        spawner.GetComponent<Animation>().enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision other)
    {
        var wavePosition = new Vector3(-3.8f, 40.6f, -8.85f);
        
        if (other.gameObject.tag == "NewWaveSpawner")
        {
            Debug.Log("soea");
            Instantiate(wave, wavePosition, Quaternion.identity);
            spawner.GetComponent<Animation>().Play("SpawnNewWave");
        }
    }
}
