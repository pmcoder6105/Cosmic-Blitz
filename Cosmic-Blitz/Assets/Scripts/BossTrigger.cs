using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    [Tooltip("The timeline that will start when you cross a trigger")][SerializeField] GameObject Level6BossFightTimeline;
    [Tooltip("The trigger that needs to be triggered to activate boss timeline")][SerializeField] GameObject BossTriggerObject;


    //When you collide with the boss trigger,
    //set the boss fight timeline active
    //and destroy the boss trigger object immediatly
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "BossTrigger")
        {
            Level6BossFightTimeline.SetActive(true);
            Destroy(BossTriggerObject);
        }
    }
}
