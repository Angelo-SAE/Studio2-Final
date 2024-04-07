using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "PlayerPosition", menuName = "GeneralScriptableObjects/PlayerPosition", order = 100)]
public class PlayerPosition : ScriptableObject
{
    public Vector3 position;
}
