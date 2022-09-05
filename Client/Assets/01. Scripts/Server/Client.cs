using WebSocketSharp;
using UnityEngine;
using Newtonsoft.Json;

public class Client : MonoBehaviour
{
    public static Client Instance = null;

    [SerializeField] string IP = "localhost", PORT = "3031";
    private WebSocket server;
    private object locker = new object();

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

        server = new WebSocket("ws://" + IP + ":" + PORT); //해당 URL로 웹 소켓 서버 생성
        server.ConnectAsync(); //웹 소켓 서버 접속

        server.OnMessage += GetMessages; //OnMessage 이벤트가 실행될 때 GetMessages 실행
    }

    /// <summary>
    /// 서버에서 보내온 메세지 데이터 파싱
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="args"></param>
    private void GetMessages(object sender, MessageEventArgs args)
    {
        lock(locker)
        {
            Packet packet = JsonConvert.DeserializeObject<Packet>(args.Data); //string 값의 데이터를 Packet(class) 형식으로 파싱

            switch(packet.locate) //Packet 의 locate 를 기준으로 switch & case
            {
                case "room": //서버에서 보내온 Packet 의 locate 값이 room 일 때 RoomData 메소드 실행

                    break;
                case "game": //서버에서 보내온 Packet 의 locate 값이 game 일 때 GameData 메소드 실행
                    break;
                case "error": //서버에서 보내온 Packet의 locate 값이 error일 때 Packet의 value 값 로그 띄우기
                    Debug.Log(packet.value);
                    break;
            }
        }
    }

    /// <summary>
    /// 룸 관련 데이터를 처리하는 메소드
    /// </summary>
    /// <param name="_packet">서버에서 보낸 데이터 (Packet)</param>
    private void RoomData(Packet _packet)
    {
        switch(_packet.type) //Packet 의 type 을 기준으로 switch & case
        {
            case "joinRes":
                break;
            case "createRes":
                break;
            case "quitRes":
                break;
        }
    }

    /// <summary>
    /// 게임 관련 데이터를 처리하는 메소드
    /// </summary>
    /// <param name="_packet">서버에서 보낸 데이터 (Packet)</param>
    private void GameData(Packet _packet)
    {
        switch(_packet.type) //Packet 의 type 을 기준으로 switch & case
        {
            case "move":
                break;
            case "input":
                break;
            case "damage":
                break;
        }
    }
}
