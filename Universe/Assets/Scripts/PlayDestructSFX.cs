using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayDestructSFX : MonoBehaviour
{
    Player player;
    AudioSource aS;
    [SerializeField] AudioClip destruction;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        aS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.enabled == false)
        {
            if (!aS.isPlaying)
            {
                aS.PlayOneShot(destruction);
            }
        }
    }
}
