using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RoomSpots", menuName = "Rooms/RoomSpots", order = 100)]
public class RoomSpots : ScriptableObject
{
    public GameObject[,] rooms = new GameObject[10,10];
}
