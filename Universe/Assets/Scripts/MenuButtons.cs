using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    public void PlayFirstLevelOnPlayClick()
    {
        SceneManager.LoadScene(1);
    }
}
