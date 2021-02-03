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
        if (GameManager.instance.menuState == Vector3Int.zero)
        {
            GameManager.instance.menuState = new Vector3Int(1, 0, 0);
        }
        SetMenu(GameManager.instance.menuState);
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

        GameManager.instance.menuState = tmp;
    }

    public void StartOnClick()
    {
        if(GameManager.instance.menuState == new Vector3Int(1, 0, 0))
        {
            SetMenu(new Vector3Int(0, 1, 0));
        }
        else
        {
            Debug.LogError(GameManager.instance.menuState + "出现了意料之外的数据");
        }
    }

    public void SettingOnClick()
    {
        if(GameManager.instance.menuState==new Vector3Int(1, 0, 0))
        {
            SetMenu(new Vector3Int(2, 0, 0));
        }
        else if(GameManager.instance.menuState == new Vector3Int(2, 0, 0))
        {
            SetMenu(new Vector3Int(1, 0, 0));
        }
        else
        {
            Debug.LogError(GameManager.instance.menuState + "出现了意料之外的数据");
        }
    }

    public void ExitOnClick()
    {
        Application.Quit();
    }
}
