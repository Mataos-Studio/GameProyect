using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RoomCreator : MonoBehaviour
{
    private const int MapSize = 100;
    private int[,] roomMap = new int[MapSize,MapSize];
    private List<int> roomList = new();
    [SerializeField] private RoomListData roomListdata;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        roomListdata.RoomListDataInitializer();
        RoomData room = CreateRoom(new Vector2Int(0,0));
        GameObject rObj = Instantiate(room.GetPrefab());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public RoomData CreateRoom(Vector2Int pos)
    {
        RoomData result = roomListdata.GetRoomData(0);
        result.SetOrigin(pos);
        if(RoomFits(result))
        {
            SetRoom(result);
        }
        return result;
    }

    private bool RoomFits(RoomData room)
    {
        bool result = true;
        Vector2Int startPos = room.GetOrigin();
        Vector2Int endPos = startPos + room.GetSize();
        int id = room.GetId();
        for(int i = startPos.x; i < endPos.x; i++)
        {
            for(int j = startPos.y; j < endPos.y; j++)
            {
                if(roomMap[i,j] != 0)
                {
                    result = false;
                    return result;
                }
            }
        }
        return result;
    }

    private void SetRoom(RoomData room)
    {
        Vector2Int startPos = room.GetOrigin();
        Vector2Int endPos = startPos + room.GetSize();
        int id = room.GetId();
        for(int i = startPos.x; i < endPos.x; i++)
        {
            for(int j = startPos.y; j < endPos.y; j++)
            {
                roomMap[i,j] = id;
            }
        }
        roomList.Add(id);
    }
}
