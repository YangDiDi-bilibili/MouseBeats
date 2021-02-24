using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    public AudioSource bgm;

    public List<AudioClip> audioClips = new List<AudioClip>();

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

        if (bgm == null)
        {
            var tmpObj = new GameObject();
            bgm = tmpObj.AddComponent<AudioSource>();
        }
    }

    /// <summary>
    /// 调节音频播放速度
    /// </summary>
    /// <param name="speed"></param>
    public void SetPlaySpeed(float speed)
    {
        bgm.pitch = speed;
    }
}
