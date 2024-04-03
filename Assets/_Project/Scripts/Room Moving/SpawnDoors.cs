using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnDoors : MonoBehaviour, IObserver
{
    [SerializeField] private GameObject doorNS, doorEW;
    [SerializeField] private ModeChanger observable;
    [SerializeField] private RoomSpots roomSpots;
    [SerializeField] private int roomsX, roomsY;
    [SerializeField] private GameObject doorHolder;
    private bool[,] doorSpawnedNS;
    private bool[,] doorSpawnedEW;
    private List<int>[,] doorSpots;
    private int ok = 0;

    private void Awake()
    {
      doorSpots = new List<int>[roomsX, roomsY];
      AddSelfToObservable();
    }

    public void AddSelfToObservable()
    {
      observable.AddObserver(this);
    }

    public void PerformObserableAction(bool recievedVariable)
    {
      if(recievedVariable && ok > 0)
      {
        StoreDoorSpots();
        CheckRooms();
      } else {
        ok++;
      }
    }

    private void StoreDoorSpots()
    {
      for(int a = 0; a < roomsX; a++)
      {
        for(int b = 0; b < roomsY; b++)
        {
          doorSpots[a,b] = new List<int>();
          if(roomSpots.rooms[a,b] is not null)
          {
            doorSpots[a,b] = roomSpots.rooms[a,b].GetComponent<DoorSpots>().DoorSpotsDirections;
          }
        }
      }
    }

    private void CheckRooms()
    {
      doorSpawnedNS = new bool[roomsX + 1,roomsY + 1];
      doorSpawnedEW = new bool[roomsX + 1,roomsY + 1];
      if(doorHolder is not null)
      {
        Destroy(doorHolder);
      }
      doorHolder = new GameObject("DoorsHolder");
      for(int a = 0; a < roomsX; a++)
      {
        for(int b = 0; b < roomsY; b++)
        {
          CheckForSpawningDoors(a, b);
        }
      }
    }

    private void CheckForSpawningDoors(int a, int b)
    {
      if(doorSpots[a,b].Contains(0) && !doorSpawnedNS[a,b + 1])
      {
        if(b + 1 < roomsY)
        {
          if(doorSpots[a,b + 1].Contains(2))
          {
            Instantiate(doorNS, new Vector3(doorNS.transform.position.x + a * 15f, doorNS.transform.position.y, doorNS.transform.position.z + 7.5f + b * 15f), doorNS.transform.rotation, doorHolder.transform);
            doorSpawnedNS[a,b + 1] = true;
          } else {
            GameObject currentdoor = Instantiate(doorNS, new Vector3(doorNS.transform.position.x + a * 15f, doorNS.transform.position.y, doorNS.transform.position.z + 7.5f + b * 15f), doorNS.transform.rotation, doorHolder.transform);
            currentdoor.GetComponent<DoorInteract>().CanOpen = false;
            doorSpawnedNS[a,b + 1] = true;
          }
        } else {
          GameObject currentdoor = Instantiate(doorNS, new Vector3(doorNS.transform.position.x + a * 15f, doorNS.transform.position.y, doorNS.transform.position.z + 7.5f + b * 15f), doorNS.transform.rotation, doorHolder.transform);
          currentdoor.GetComponent<DoorInteract>().CanOpen = false;
          doorSpawnedNS[a,b + 1] = true;
        }
      }
      if(doorSpots[a,b].Contains(1) && !doorSpawnedEW[a + 1,b])
      {
        if(a + 1 < roomsX)
        {
          if(doorSpots[a + 1,b].Contains(3))
          {
            Instantiate(doorEW, new Vector3(doorEW.transform.position.x + 7.5f + a * 15f, doorEW.transform.position.y, doorEW.transform.position.z + b * 15f), doorEW.transform.rotation, doorHolder.transform);
            doorSpawnedEW[a + 1,b] = true;
          } else {
            GameObject currentdoor = Instantiate(doorEW, new Vector3(doorEW.transform.position.x + 7.5f + a * 15f, doorEW.transform.position.y, doorEW.transform.position.z + b * 15f), doorEW.transform.rotation, doorHolder.transform);
            currentdoor.GetComponent<DoorInteract>().CanOpen = false;
            doorSpawnedEW[a + 1,b] = true;
          }
        } else {
          GameObject currentdoor = Instantiate(doorEW, new Vector3(doorEW.transform.position.x + 7.5f + a * 15f, doorEW.transform.position.y, doorEW.transform.position.z + b * 15f), doorEW.transform.rotation, doorHolder.transform);
          currentdoor.GetComponent<DoorInteract>().CanOpen = false;
          doorSpawnedEW[a + 1,b] = true;
        }
      }
      if(doorSpots[a,b].Contains(2) && !doorSpawnedNS[a,b])
      {
        if(b > 0)
        {
          if(doorSpots[a,b - 1].Contains(0))
          {
            Instantiate(doorNS, new Vector3(doorNS.transform.position.x + a * 15f, doorNS.transform.position.y, doorNS.transform.position.z - 7.5f + b * 15f), doorNS.transform.rotation, doorHolder.transform);
            doorSpawnedNS[a,b] = true;
          } else {
            GameObject currentdoor = Instantiate(doorNS, new Vector3(doorNS.transform.position.x + a * 15f, doorNS.transform.position.y, doorNS.transform.position.z - 7.5f + b * 15f), doorNS.transform.rotation, doorHolder.transform);
            currentdoor.GetComponent<DoorInteract>().CanOpen = false;
            doorSpawnedNS[a,b] = true;
          }
        } else {
          GameObject currentdoor = Instantiate(doorNS, new Vector3(doorNS.transform.position.x + a * 15f, doorNS.transform.position.y, doorNS.transform.position.z - 7.5f + b * 15f), doorNS.transform.rotation, doorHolder.transform);
          currentdoor.GetComponent<DoorInteract>().CanOpen = false;
          doorSpawnedNS[a,b] = true;
        }
      }
      if(doorSpots[a,b].Contains(3) && !doorSpawnedEW[a,b])
      {
        if(a > 0)
        {
          if(doorSpots[a - 1,b].Contains(1))
          {
            Instantiate(doorEW, new Vector3(doorEW.transform.position.x - 7.5f + a * 15f, doorEW.transform.position.y, doorEW.transform.position.z + b * 15f), doorEW.transform.rotation, doorHolder.transform);
            doorSpawnedEW[a,b] = true;
          } else {
            GameObject currentdoor = Instantiate(doorEW, new Vector3(doorEW.transform.position.x - 7.5f + a * 15f, doorEW.transform.position.y, doorEW.transform.position.z + b * 15f), doorEW.transform.rotation, doorHolder.transform);
            currentdoor.GetComponent<DoorInteract>().CanOpen = false;
            doorSpawnedEW[a,b] = true;
          }
        } else {
          GameObject currentdoor = Instantiate(doorEW, new Vector3(doorEW.transform.position.x - 7.5f + a * 15f, doorEW.transform.position.y, doorEW.transform.position.z + b * 15f), doorEW.transform.rotation, doorHolder.transform);
          currentdoor.GetComponent<DoorInteract>().CanOpen = false;
          doorSpawnedEW[a,b] = true;
        }
      }
    }
}
