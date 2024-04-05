using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Note : Interactable
{
    [SerializeField] private string noteText;
    [SerializeField] private TMP_Text tmpText;
    [SerializeField] private GameObject noteCanvas;
    [SerializeField] private Publisher publisher;
    [SerializeField] private Mode mode;

    private void Start()
    {
      tmpText.text = noteText;
    }

    public override void Interact()
    {
      DisplayNote();
    }

    private void DisplayNote()
    {
      mode.mode3D = false;
      noteCanvas.SetActive(true);
      publisher.NotifySubscribers();
    }

    public void CloseNote()
    {
      mode.mode3D = true;
      noteCanvas.SetActive(false);
      publisher.NotifySubscribers();
    }
}
