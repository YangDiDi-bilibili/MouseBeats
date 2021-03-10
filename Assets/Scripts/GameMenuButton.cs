using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameMenuButton : MonoBehaviour
{
    public GameObject pausePanel;

    public void PausePanel()
    {
        pausePanel.SetActive(true);
    }

    public void GamePanel()
    {
        pausePanel.SetActive(false);
    }
}
