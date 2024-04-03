using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorSpots : MonoBehaviour
{
    [SerializeField] private List<int> doorSpotsDirections;

    public List<int> DoorSpotsDirections => doorSpotsDirections;
}
