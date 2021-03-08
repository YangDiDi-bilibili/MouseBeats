﻿using System.Collections;
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

		director = GameObject.FindGameObjectsWithTag("Director")[0].GetComponent<PlayableDirector>();
	}

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
			SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void SwitchScene(int sceneIndex)
	{
		ResetAllValue();
		SceneManager.LoadScene(sceneIndex);
	}

	public void SetGameSpeed(float speed)
    {
		Time.timeScale = speed;
    }
	public void StartGame()
	{
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

	private void ResetAllValue()
	{
	}
}
