using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    //This method is for loading the first level from clicking play in the menu selection
    public void PlayFirstLevelOnPlayClick()
    {
        SceneManager.LoadScene(1);
    }

    //This method is for loading the first level in level selection
    public void PlayFirstLevelOnLevelSelect()
    {
        SceneManager.LoadScene(1);
    }

    //This method is for loading the second level in level selection
    public void PlaySecondLevelOnLevelSelect()
    {
        SceneManager.LoadScene(2);
    }

    //This method is for loading the second level in level selection
    public void PlayThirdLevelOnLevelSelect()
    {
        SceneManager.LoadScene(3);
    }

    //This method is for loading the third level in level selection
    public void PlayFourthLevelOnLevelSelect()
    {
        SceneManager.LoadScene(4);
    }

    //This method is for loading the fourth level in level selection
    public void PlayFifthLevelOnLevelSelect()
    {
        SceneManager.LoadScene(5);
    }

    //This method is for loading the sixth level in level selection
    public void PlaySixthLevelOnLevelSelect()
    {
        SceneManager.LoadScene(6);
    }

    //If you click the quit button, you quit the app
    //Since we can't do that in the inspector, we just do a debug.log
    public void QuitWhenQuitButtonIsClicked()
    {
        Application.Quit();
        Debug.Log("quit");
    }

    //This method is for loading the bonus level in the menu && ending
    public void PlayBonusLevel()
    {
        SceneManager.LoadScene(9);
    }
}
