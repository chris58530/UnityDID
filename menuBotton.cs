using UnityEngine;
using UnityEngine.SceneManagement;

public class menuBotton : MonoBehaviour
{
 
    public void startButton()
    {
        SceneManager.LoadScene(1);
    }
    public void continueButton()
    {

    }
    public void quitButton()
    {
        Application.Quit();
    }
}
