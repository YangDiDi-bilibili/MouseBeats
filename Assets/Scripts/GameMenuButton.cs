using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class GameMenuButton : MonoBehaviour
{
    public GameObject gamePanel;
    public GameObject pausePanel;
    public GameObject endPanel;

    public CanvasGroup canvasGroup;

    public void PausePanel()
    {
        pausePanel.SetActive(true);
    }

    public void GamePanel()
    {
        pausePanel.SetActive(false);
    }

    public void OnLevelEnded()
    {
        gamePanel.SetActive(false);
        endPanel.SetActive(true);
    }
}
