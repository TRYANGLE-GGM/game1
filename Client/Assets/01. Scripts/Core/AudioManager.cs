using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance = null;

    [SerializeField] List<AudioClip> clipList = new List<AudioClip>();
    private Dictionary<string, AudioClip> clips = new Dictionary<string, AudioClip>();

    private void Awake()
    {
        if (Instance != null)
        {
            Debug.LogWarning("Multiple " + this.GetType() + " is Running, Destroy This");
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(transform.root.gameObject);
        }

        foreach(AudioClip ac in clipList)
        {
            string clipName = ac.name;
            
            if(!clips.ContainsKey(clipName))
                clips.Add(clipName, ac);
        }
    }

    public void Play(string _clipName, AudioSource _player)
    {
        _player.volume = DataManager.Instance.PlayerSetting.volume;

        _player.clip = null;
        _player.clip = clips[_clipName];
        _player.Play();
    }

    public void Pause(AudioSource _player)
    {
        _player.Pause();
    }
}
