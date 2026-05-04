using Unity.VisualScripting;
using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(fileName = "RoomListData", menuName = "Scriptable Objects/RoomListData")]
public class RoomListData : ScriptableObject
{
    private Dictionary<int, RoomData> RoomDatas = new();
    private Dictionary<int, GameObject> RoomObjects = new();

    public RoomData GetRoomData(int id)
    {
        RoomData result = RoomDatas[id];
        if(result == null)
        {
            Debug.Log("Id no registrado");
        }
        return result;
    }

    public GameObject GetRoomObject(int id)
    {
        GameObject result = RoomObjects[id];
        if(result == null)
        {
            Debug.Log("Id no registrado");
        }
        return result;
    }

    //Información de las habitaciones
    public void RoomListDataInitializer()
    {
        RoomObjects.Add(0, (GameObject)Resources.Load("Room0", typeof(GameObject)));
        RoomDatas.Add(0, new RoomData(RoomObjects[0], 0, new Vector2Int(1,1)));
    }
}
