using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;

public class RoomData
{
    private List<Door> doors = new();
    private Vector2Int origin = new();
    private int id;
    private Vector2Int size = new();
    private GameObject roomObj;
    
    public RoomData(GameObject room, int id, Vector2Int size)
    {
        roomObj = room;
        this.id = id;
        this.size = size;
    }

    public bool AddDoor(Door door)
    {
        if(door != null)
        {
            doors.Add(door);
            return true;            
        } else
        {
            return false;
        }
    }

    public Vector2Int GetSize()
    {
        return size;
    }

    public Vector2Int GetOrigin()
    {
        return origin;
    }

    public int GetId()
    {
        return id;
    }

    public GameObject GetPrefab()
    {
        return roomObj;
    }

    public void SetOrigin(Vector2Int pos)
    {
        if(pos != null)
        {
            origin = pos;
        } else
        {
            Debug.Log("Posición nula");
        }
    }
}
