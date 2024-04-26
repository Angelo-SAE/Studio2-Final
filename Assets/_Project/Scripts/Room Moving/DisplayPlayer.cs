using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisplayPlayer : MonoBehaviour
{
    [SerializeField] private Room room;
    [SerializeField] private GameObject playerMarker;
    [SerializeField] private Vector3Object playerRotation;

    public void OnNotify()
    {
      Set2DPlayerPosition();
    }

    private void Set2DPlayerPosition()
    {
      playerMarker.transform.localPosition = new Vector3(room.PlayerPositionInRoom.x, room.PlayerPositionInRoom.z, playerMarker.transform.localPosition.z);
      playerMarker.transform.eulerAngles = new Vector3(0f, 0f, -playerRotation.value.y);
    }
}
