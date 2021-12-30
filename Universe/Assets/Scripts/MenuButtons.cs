using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
    public void PlayFirstLevelOnPlayClick()
    {
        SceneManager.LoadScene(1);
    }

    public void PlayFirstLevelOnLevelSelect()
    {
        SceneManager.LoadScene(1);
    }

    public void PlaySecondLevelOnLevelSelect()
    {
        SceneManager.LoadScene(2);
    }

    public void PlayThirdLevelOnLevelSelect()
    {
        SceneManager.LoadScene(3);
    }

    public void PlayFourthLevelOnLevelSelect()
    {
        SceneManager.LoadScene(4);
    }

    public void PlayFifthLevelOnLevelSelect()
    {
        SceneManager.LoadScene(5);
    }

    public void PlaySixthLevelOnLevelSelect()
    {
        SceneManager.LoadScene(6);
    }
}
