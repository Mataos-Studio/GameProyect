using UnityEngine;
using UnityEngine.SocialPlatforms;

public class Door
{
    private Door linkedDoor;
    private Vector2Int localPos = new();
    private int dir; // 1: Up | 2: Right | 3: Down | 4: Left
    private int id;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool SetLinkedDoor(Door lDoor)
    {
        if(lDoor != null)
        {
            linkedDoor = lDoor;
            return true;
        } else
        {
            return false;
        }
    }

    private void SendToLinkedDoor()
    {
        
    }

    public Vector2Int GetLocalPos()
    {
        return localPos;
    }

    public int GetDir()
    {
        return dir;
    }
}
