using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	public static GameManager instance;

	public Vector3Int menuState;

	public float timeScale;
	public static bool doGameGoing;

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
		doGameGoing = true;
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

    private void Start()
    {
		SetGameSpeed(timeScale);
	}

	public void SetGameSpeed(float speed)
    {
		Time.timeScale = speed;
		AudioManager.instance.SetPlaySpeed(speed);
    }

	public void PauseGame()
    {
        if (doGameGoing)
        {
			SetGameSpeed(0);
			doGameGoing = false;
        }
        else
        {
			SetGameSpeed(timeScale);
			doGameGoing = true;
        }
	}

	private void ResetAllValue()
	{
	}
}
