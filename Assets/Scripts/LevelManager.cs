using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

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

	public void QuitRequest() 
	{
		Application.Quit();
	}

}
