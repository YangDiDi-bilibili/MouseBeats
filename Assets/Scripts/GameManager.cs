using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	private void Awake()
	{
		if (instance != null)
		{
			Destroy(gameObject);
		}

		instance = this;
		DontDestroyOnLoad(gameObject);
	}

	public void SwitchScene(int sceneIndex)
	{
		ResetAllValue();
		SceneManager.LoadScene(sceneIndex);
	}

    private void Start()
    {
		Time.timeScale = 1.0f;
    }

    private void ResetAllValue()
	{
	}
}
