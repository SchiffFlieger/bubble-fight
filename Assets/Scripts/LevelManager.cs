using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public float loadNextLevelAfter;

    void Start()
    {
        if (loadNextLevelAfter > 0)
        {
            Invoke("LoadNextLevel", loadNextLevelAfter);
        }
    }

    public void LoadLevel(string name)
    {
        if (name.Equals("Game"))
        {
            ScoreManager.Reset();
            StaticWriter.round = 0;
            StaticWriter.session = StaticWriter.RandomString(10);
        }
        SceneManager.LoadScene(name);
    }

    private void LoadNextLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitRequest()
    {
        Application.Quit();
    }
}
