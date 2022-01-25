using UnityEngine;
public class BGSoundScript : MonoBehaviour
{
    //This script is to make sure that the music plays through all scenes and doesn't restart when scene changes
    //Don't change this script
    
    private static BGSoundScript instance = null;
    public static BGSoundScript Instance
    {
        get { return instance; }
    }
    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        else
        {
            instance = this;
        }
        DontDestroyOnLoad(this.gameObject);
    }
}