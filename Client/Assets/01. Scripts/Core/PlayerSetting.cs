using UnityEngine;
using Newtonsoft.Json;

[System.Serializable]
public class PlayerSetting
{
    [Range(0f, 1f), JsonProperty("volume")] public float volume;

    public PlayerSetting(float _volume)
    {
        this.volume = _volume;
    }
}
