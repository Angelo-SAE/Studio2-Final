using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room2D : MonoBehaviour, IObserver
{
    [SerializeField] private int activeNumber;
    [SerializeField] private RoomSpots roomSpots;
    [SerializeField] private Current2D currentCamera;
    [SerializeField] private ModeChanger observable;
    [SerializeField] private GameObject room;
    [SerializeField] private Collider2D col2D;
    [SerializeField] private SpriteRenderer spirte;
    private bool isActive;
    private bool roomUpdate;
    //private bool mode3D;

    private void Awake()
    {
      AddSelfToObservable();
    }

    private void Start()
    {
      SetDefaultRoom();
    }

    public void AddSelfToObservable()
    {
      observable.AddObserver(this);
    }

    public void PerformObserableAction(bool recievedVariable)
    {
      //mode3D = recievedVariable;
      UpdateRoomPosition();
    }

    private void Update()
    {
      CheckIfEnabled();
    }

    private void CheckIfEnabled()
    {
      if(currentCamera.cameraNumber >= activeNumber && isActive)
      {
        col2D.enabled = true;
        spirte.enabled = true;
        isActive = false;
      } else if(currentCamera.cameraNumber < activeNumber && !isActive)
      {
        col2D.enabled = false;
        spirte.enabled = false;
        isActive = true;
      }
    }

    private void SetDefaultRoom()
    {
      roomSpots.rooms[(int)transform.position.x, (int)transform.position.y] = gameObject;
    }

    private void UpdateRoomPosition()
    {
      room.transform.position = new Vector3(transform.position.x * 15, 0f, transform.position.y * 15);
    }
}
