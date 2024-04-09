using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : Interactable
{
    [SerializeField] private int buttonNumber;
    [SerializeField] private SafeCode safeCode;

    public override void Interact()
    {
      safeCode.AddAndUpdate(buttonNumber);
    }

}
