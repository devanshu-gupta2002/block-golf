using UnityEngine.SceneManagement;
using UnityEngine;

public class GoToMenu : MonoBehaviour
{
    public void GoTomenu()
    {

        SceneManager.LoadScene(0);
    }
    public void QuitGame()
	{
        Application.Quit();
	}
}
