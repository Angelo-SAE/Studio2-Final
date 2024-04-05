using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Note : Interactable
{
    [SerializeField] private string noteText;
    [SerializeField] private TMP_Text tmpText;
    [SerializeField] private GameObject noteCanvas;
    [SerializeField] private Mode mode3D;
    [SerializeField] private ModeChanger modeChanger;

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
      modeChanger.ChangeMode2();
      noteCanvas.SetActive(true);
    }

    public void CloseNote()
    {
      noteCanvas.SetActive(false);
    }
}
