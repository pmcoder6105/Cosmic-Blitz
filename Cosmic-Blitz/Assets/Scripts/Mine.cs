using UnityEngine;

public class Mine : MonoBehaviour
{
    [Tooltip("Amount of hits the mine can take before destroying")][SerializeField] int hitPoints = 7;
    
    
    [Header("All mine visuals")]
    [Tooltip("Explosion vfx that plays when mine explodes")][SerializeField] ParticleSystem mineExplosion;
    [Tooltip("Sparks vfx that plays when mine takes damage")] [SerializeField] ParticleSystem hitSpark;
    [Tooltip("Fuse vfx that plays constantly")] [SerializeField] ParticleSystem fuse;
    
   
    [Header("References")]
    [Tooltip("Referencing audiosource component")] AudioSource aS;
    
    [Header("Audio Clips")]
    [Tooltip("Explosion sfx that plays when mine explodes")] [SerializeField] AudioClip destruction;

    
    //Cache references
    void Start()
    {
        aS = GetComponent<AudioSource>();
    }

    
    //On Particle collision 
    void OnParticleCollision(GameObject other)
    {
        //If the particle collisions are from the player
        //Reduce hitpoints by 1
        //play hit spark vfx
        if (other.gameObject.tag == "Player")
        {
            hitPoints = hitPoints - 1;
            hitSpark.Play();            
            if (hitPoints == 0)
            {
                if (!aS.isPlaying)
                {
                    aS.PlayOneShot(destruction);
                }
                GetComponent<MeshRenderer>().enabled = false;
                GetComponent<Mine>().enabled = false;
                GetComponent<BoxCollider>().enabled = false;
                GetComponent<Animator>().enabled = false;
                if (!mineExplosion.isPlaying)
                {
                    mineExplosion.Play();
                }
                if (!fuse.isStopped)
                {
                    fuse.Stop();
                }
                Invoke(nameof(DestroyWhenDestroyed), 2f);                
            }
        }
    }

    //On collision
    void OnCollisionEnter(Collision other)
    {
        //If the collisions are from the player
        //Reduce hitpoints by 1
        //play hit spark vfx
        if (other.gameObject.tag == "Player")
        {
            hitPoints = hitPoints - 1;
            hitSpark.Play();
            if (hitPoints == 0)
            {
                if (!mineExplosion.isPlaying)
                {
                    mineExplosion.Play();
                }
                GetComponent<MeshRenderer>().enabled = false;
                GetComponent<Mine>().enabled = false;
                GetComponent<BoxCollider>().enabled = false;
                GetComponent<Animator>().enabled = false;
                if (!fuse.isStopped)
                {
                    fuse.Stop();
                }
                Invoke(nameof(DestroyWhenDestroyed), 2f);
            }            
        }
    }
    
    //Destroy mine when destroyed
    void DestroyWhenDestroyed()
    {
        Destroy(gameObject);
    }
}
