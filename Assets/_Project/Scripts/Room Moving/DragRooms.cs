using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragRooms : MonoBehaviour
{
    [SerializeField] private int[] ArrayBoundsX;
    [SerializeField] private int[] ArrayBoundsY;
    [SerializeField] private Current2D currentCamera;
    [SerializeField] private RoomSpots roomSpots;
    [SerializeField] private Camera[] cameras;
    [SerializeField] private Mode mode;
    [SerializeField] private AudioSources[] dropRoomSound;
    private DraggableObject dragObject;
    private GameObject draggableObject;
    private Vector2 mousePosition, mouseClickPosition, origionalPosition;

    private void Update()
    {
      if(!mode.mode3D)
      {
        GetMousePosition();
        GetDraggableObject();

        if(draggableObject != null)
        {
          MoveDraggableObject();
        }
      }
    }

    private void GetMousePosition()
    {
      mousePosition = cameras[currentCamera.cameraNumber].ScreenToWorldPoint(Input.mousePosition);
    }

    private void GetDraggableObject()
    {
      if(Input.GetMouseButtonDown(0))
      {
        Collider2D targetObject = Physics2D.OverlapPoint(mousePosition);

        if(targetObject != null)
        {
          if(targetObject.tag == "Draggable")
          {
            dragObject = targetObject.gameObject.GetComponent<DraggableObject>();
            if(dragObject.CanDrag)
            {
              dragObject.OnPickup();
              draggableObject = targetObject.transform.gameObject;
              mouseClickPosition = mousePosition;
              origionalPosition = new Vector2(draggableObject.transform.position.x, draggableObject.transform.position.y);
            }
          }
        }
      }
      if(Input.GetMouseButtonUp(0))
      {
        if(draggableObject != null)
        {
          dragObject.OnDrop();
          SetPositionOfObject();
          draggableObject = null;
        }
      }
    }

    private void MoveDraggableObject()
    {
      draggableObject.transform.position = new Vector3(mousePosition.x, mousePosition.y, draggableObject.transform.position.z);
    }

    private void SetPositionOfObject()
    {
      Vector2 tempPosition = new Vector2(draggableObject.transform.position.x, draggableObject.transform.position.y);
      Vector2 closest = origionalPosition;
      float closestDistance = 10000000000f;
      float tempDistance;
      for(int a = 0; a < ArrayBoundsX[currentCamera.cameraNumber]; a++)
      {
        for(int b = 0; b < ArrayBoundsY[currentCamera.cameraNumber]; b++)
        {
          tempDistance = Vector2.Distance(tempPosition, new Vector2(a,b));
          if(tempDistance < closestDistance)
          {
            closestDistance = tempDistance;
            closest = new Vector2(a,b);
          }
        }
      }
      if(roomSpots.rooms[(int)closest.x, (int)closest.y] is null)
      {
        roomSpots.rooms[(int)origionalPosition.x, (int)origionalPosition.y] = null;
        dropRoomSound[(int)closest.x].y[(int)closest.y].Play();
        roomSpots.rooms[(int)closest.x, (int)closest.y] = draggableObject;
        draggableObject.transform.position = new Vector3(closest.x, closest.y, draggableObject.transform.position.z);
      } else {
        draggableObject.transform.position = new Vector3(origionalPosition.x, origionalPosition.y, draggableObject.transform.position.z);
      }
    }
}

[System.Serializable]
public struct AudioSources
{
  public AudioSource[] y;
}
