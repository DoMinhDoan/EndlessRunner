using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    public GameObject[] availableRooms;
    public List<GameObject> currentRooms;
    public GameObject target;

    private float screenWidthInPoint;

    // Start is called before the first frame update
    void Start()
    {
        float height = 2.0f * Camera.main.orthographicSize;
        screenWidthInPoint = height * Camera.main.aspect;

        StartCoroutine(CheckMapGenerator());
    }

    void AddRoom(float farthestRoomEndX)
    {
        int randomIndex = Random.Range(0, availableRooms.Length);

        GameObject background = Instantiate(availableRooms[randomIndex]);

        float backgroundWidth = background.transform.Find("Floor").localScale.x;
        float roomCenter = farthestRoomEndX + (backgroundWidth / 2);
        background.transform.position = new Vector3(roomCenter, 0, 0);

        currentRooms.Add(background);
    }

    private void AddRoomIfNeed()
    {
        List<GameObject> roomToRemove = new List<GameObject>();
        bool addRoom = true;

        float playerX = target.transform.position.x;
        float removeRoomX = playerX - screenWidthInPoint;
        float addRoomX = playerX + screenWidthInPoint;

        float farthestRoomEndX = 0;
        foreach(var room in currentRooms)
        {
            float roomWidth = room.transform.Find("Floor").localScale.x;
            float roomStartX = room.transform.position.x - (roomWidth / 2);
            float roomEndX = roomStartX + roomWidth;

            if (roomEndX < removeRoomX)
            {
                roomToRemove.Add(room);
            }

            if(roomStartX > addRoomX)
            {
                addRoom = false;
            }
            farthestRoomEndX = Mathf.Max(farthestRoomEndX, roomEndX);
        }

        if(addRoom == true)
        {
            AddRoom(farthestRoomEndX);
        }

        foreach (var room in roomToRemove)
        {
            currentRooms.Remove(room);
            Destroy(room);
        }
    }

    private IEnumerator CheckMapGenerator()
    {
        while(true)
        {
            AddRoomIfNeed();
            yield return new WaitForSeconds(0.25f);            
        }
    }
}
