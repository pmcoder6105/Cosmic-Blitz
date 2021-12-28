using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    [SerializeField] GameObject MasterTimeline6;
    [SerializeField] GameObject Level6BossFightTimeline;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "BossTrigger")
        {
            MasterTimeline6.SetActive(false);
            Level6BossFightTimeline.SetActive(true);
        }
    }
}
