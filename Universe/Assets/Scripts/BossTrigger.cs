using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossTrigger : MonoBehaviour
{
    [SerializeField] GameObject Level6BossFightTimeline;
    [SerializeField] GameObject BossTriggerObject;


    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "BossTrigger")
        {
            Level6BossFightTimeline.SetActive(true);
            Destroy(BossTriggerObject);
        }
    }
}
