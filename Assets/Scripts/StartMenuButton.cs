using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartMenuButton : MonoBehaviour
{
    public GameObject startMenu;
    public GameObject settingMenu;
    public GameObject albumMenu;

    private void Start()
    {
        if (GameManager.menuState == Vector3Int.zero)
        {
            GameManager.menuState = new Vector3Int(1, 0, 0);
        }
        SetMenu(GameManager.menuState);
    }

    public void SetMenu(Vector3Int tmp)
    {
        if (tmp.x != 0)
        {
            if (tmp.x == 1)
            {
                startMenu.SetActive(true);
                settingMenu.SetActive(false);
                albumMenu.SetActive(false);
            }else if (tmp.x == 2)
            {
                startMenu.SetActive(true);
                settingMenu.SetActive(true);
                albumMenu.SetActive(false);
            }
        }
        else if (tmp.y != 0)
        {
            startMenu.SetActive(false);
            settingMenu.SetActive(false);
            albumMenu.SetActive(true);
        }
        else
        {
            switch (tmp.z)
            {

                default:
                    break;
            }
        }

        GameManager.menuState = tmp;
    }

    public void StartOnClick()
    {
        if(GameManager.menuState == new Vector3Int(1, 0, 0))
        {
            SetMenu(new Vector3Int(0, 1, 0));
        }
        else
        {
            Debug.LogError(GameManager.menuState + "出现了意料之外的数据");
        }
    }

    public void SettingOnClick()
    {
        if(GameManager.menuState==new Vector3Int(1, 0, 0))
        {
            SetMenu(new Vector3Int(2, 0, 0));
        }
        else
        {
            Debug.LogError(GameManager.menuState + "出现了意料之外的数据");
        }
    }

    public void BackOnClick()
    {
        if (GameManager.menuState == new Vector3Int(2, 0, 0))
        {
            SetMenu(new Vector3Int(1, 0, 0));
        }
        else if (GameManager.menuState == new Vector3Int(0, 1, 0))
        {
            SetMenu(new Vector3Int(1, 0, 0));
        }
        else if (GameManager.menuState.x == 0 && GameManager.menuState.y == 0 && GameManager.menuState.z != 0)
        {
            GameManager.menuState.z--;
        }
        else
        {
            Debug.LogError(GameManager.menuState + "出现了意料之外的数据");
        }
    }

    public void ExitOnClick()
    {
        Application.Quit();
    }
}
