using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;
	public Setting setting;
	public PlayableDirector director;

	public bool doGameGoing;

	public event Action OnResetValue;

	private void Awake()
	{
		if (instance == null)
		{
			instance = this;
			DontDestroyOnLoad(gameObject);
		}
		else
        {
			Destroy(gameObject);
		}

		doGameGoing = false;
		SetGameSpeed(0);

		OnResetValue += GameManager_ResetValue;

		director = GameObject.FindGameObjectsWithTag("Director")[0].GetComponent<PlayableDirector>();
	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
			RelaodGame();
		}
    }

	public void RelaodGame()
    {
		SwitchScene(SceneManager.GetActiveScene().buildIndex);
	}

	public void SwitchScene(int sceneIndex)
	{
		SceneManager.LoadScene(sceneIndex);
		OnResetValue?.Invoke();
	}

	public void SetGameSpeed(float speed)
    {
		Time.timeScale = speed;
    }

	public void StartGame()
	{
        if (director == null)
        {
			director = GameObject.FindGameObjectsWithTag("Director")[0].GetComponent<PlayableDirector>();
		}

		SetGameSpeed(setting.timeScale);
		director.Play();
		doGameGoing = true;
	}

    public void PauseGame()
    {
		SetGameSpeed(0);
		director.Pause();
		doGameGoing = false;
	}

	public void ResumeGame()
    {
		SetGameSpeed(setting.timeScale);
		director.Resume();
		doGameGoing = true;
	}

	private void GameManager_ResetValue()
	{
		doGameGoing = false;
		SetGameSpeed(0);
	}
}
