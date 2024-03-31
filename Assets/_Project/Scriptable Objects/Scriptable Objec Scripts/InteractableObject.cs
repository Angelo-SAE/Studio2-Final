using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "InteractableObject", menuName = "GeneralScriptableObjects/InteractableObject", order = 100)]
public class InteractableObject : ScriptableObject
{
    public Interactable interactableObject;
}
