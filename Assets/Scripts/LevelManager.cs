using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelManager : MonoBehaviour {
    public void LoadLevel(string name)
    {
        Debug.Log("Level load requested for " + name);
		SceneManager.LoadScene (name);
    }

    public void QuitRequest()
    {
        Debug.Log("New quit request");
        Application.Quit();
    }
}
