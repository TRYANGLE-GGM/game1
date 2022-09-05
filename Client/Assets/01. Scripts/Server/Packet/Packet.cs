using Newtonsoft.Json;
using UnityEngine;

public class Packet
{
    [JsonProperty("l")] public string locate; //가장 큰 틀 ex) room, game 등등
    [JsonProperty("t")] public string type; //데이터 타입 ex) input, join, quit 등등
    [JsonProperty("v")] public string value; //데이터 값 ex) vector3값, 인풋 값 등등

    public Packet(string _locate, string _type, string _value) //string 값 value 의 Packet 생성자
    {
        this.locate = _locate;
        this.type = _type;
        this.value = _value;
    }

    public Packet(string _locate, string _type, object _value) //objcet 값 value 의 Packet 생성자
    {
        this.locate = _locate;
        this.type = _type;
        this.value = JsonConvert.SerializeObject(_value);
    }
}
