using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : Interactable
{
    [SerializeField] private int buttonNumber;
    [SerializeField] private SafeCode safeCode;
    [SerializeField] private AudioSource input;

    public override void Interact()
    {
      safeCode.AddAndUpdate(buttonNumber);
      input.Play();
    }

}
