using System.IO;
using UnityEngine;
using Newtonsoft.Json;

public class DataManager : MonoBehaviour
{
    public static DataManager Instance = null;

    public PlayerSetting PlayerSetting = null;

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

        if(!TryReadJson<PlayerSetting>(out PlayerSetting))
            PlayerSetting = new PlayerSetting(0.5f);
    }

    /// <summary>
    /// 제네릭 이름으로 된 경로의 JSON 읽고 _data로 out
    /// </summary>
    /// <param name="_data">데이터</param>
    /// <typeparam name="T">데이터 자료형</typeparam>
    /// <returns>_data 파싱 결과</returns>
    private bool TryReadJson<T>(out T _data)
    {
        string json = File.ReadAllText("./Assets/08. JSON/" + typeof(T) + ".json");
        if (json.Length > 0)
        {
            _data = JsonConvert.DeserializeObject<T>(json);
            return true;
        }
        else
        {
            _data = default(T);
            return false;
        }
    }

    /// <summary>
    /// 제네릭 이름으로 된 경로에 _data 데이터 저장 <T>T</T>
    /// </summary>
    /// <param name="_data">데이터</param>
    /// <typeparam name="T">데이터 자료형</typeparam>
    private void SaveData<T>(T _data)
    {
        string path = "./Assets/08. JSON/" + typeof(T) + ".json";
        File.WriteAllText(path, JsonConvert.SerializeObject(_data));
    }

    private void OnDisable()
    {
        SaveData<PlayerSetting>(PlayerSetting);
    }
}
