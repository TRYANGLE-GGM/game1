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

    /// <summary>
    /// _player의 오디오 소스에 _clipName 으로 된 클립 실행
    /// </summary>
    /// <param name="_clipName">실행할 클립 이름</param>
    /// <param name="_player">클립을 실행시킬 오디오 소스</param>
    public void Play(string _clipName, AudioSource _player)
    {
        _player.volume = DataManager.Instance.PlayerSetting.volume;

        _player.clip = null;
        _player.clip = clips[_clipName];
        _player.Play();
    }

    /// <summary>
    /// _player의 오디오 소스의 플레이를 일시정지
    /// </summary>
    /// <param name="_player">실행을 멈출 오디오 소스</param>
    public void Pause(AudioSource _player)
    {
        _player.Pause();
    }
}
