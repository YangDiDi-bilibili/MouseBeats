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
		if (instance != null)
		{
			Destroy(gameObject);
		}

		instance = this;
		DontDestroyOnLoad(gameObject);

		doGameGoing = true;
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
