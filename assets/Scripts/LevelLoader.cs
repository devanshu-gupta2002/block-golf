using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;

public class LevelLoader : MonoBehaviour
{
    public Animator transition;
    public float TransitionTime = 1f;
    void Update()
    {
      if(Input.GetMouseButtonDown(0)) 
		{
            LoadNextLevel();
		}
    }
    public void LoadNextLevel()
	{
        StartCoroutine(LoadLevel(SceneManager.GetActiveScene().buildIndex + 1));
	}
    IEnumerator LoadLevel(int LevelIndex)
	{
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(TransitionTime);
        SceneManager.LoadScene(LevelIndex);
	}
}
