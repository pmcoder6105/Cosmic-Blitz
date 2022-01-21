using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    //This method is for turning time to 0 when you click a certain button
    public void PauseOnClick()
    {
        Time.timeScale = 0;
    }

    //This method is for turning time to 1 when you click a certain button
    public void ResumeOnClick()
    {
        Time.timeScale = 1;
    }

    //This method is for going to the first scene, aka the menu, when you click a certain button
    public void ReturnToMenuOnClick()
    {
        SceneManager.LoadScene(0);
    }

    //This method is for reloading the scene which is used in the bonus level
    public void ReloadScene()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
}
