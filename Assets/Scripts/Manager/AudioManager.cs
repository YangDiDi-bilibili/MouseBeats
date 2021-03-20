using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    public List<AudioPrefab> audioPrefabs = new List<AudioPrefab>();
    private Queue<AudioSource> audioSources = new Queue<AudioSource>();

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

        var gObj = new GameObject();
        audioSources.Enqueue(gObj.AddComponent<AudioSource>());
        gObj.transform.parent = transform;
    }

    /// <summary>
    /// 播放音频名字
    /// </summary>
    /// <param name="soundName"></param>
    public void PlaySound(string soundName)
    {
        bool doFindClip = false;
        foreach (var item in audioPrefabs)
        {
            if (item.audioName == soundName)
            {
                AudioSource tmpSource;
                if (audioSources.Peek().isPlaying)
                {
                    var gObj = new GameObject();
                    tmpSource = gObj.AddComponent<AudioSource>();
                    gObj.transform.parent = transform;
                }
                else
                {
                    tmpSource = audioSources.Dequeue();
                }

                tmpSource.volume = GameManager.instance.setting.effectVolume;
                tmpSource.PlayOneShot(item.audioClip);
                audioSources.Enqueue(tmpSource);

                doFindClip = true;
                break;
            }
        }

        if (!doFindClip) Debug.LogError("Can't find audio Named " + soundName);
    }
}
