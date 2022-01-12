using UnityEngine.SceneManagement;
using UnityEngine;

public class PauseButton : MonoBehaviour
{
    public void PauseOnClick()
    {
        Time.timeScale = 0;
    }

    public void ResumeOnClick()
    {
        Time.timeScale = 1;
    }

    public void ReturnToMenuOnClick()
    {
        SceneManager.LoadScene(0);
    }
}
