using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SafeCode : MonoBehaviour
{
    [SerializeField] private List<int> safeCode;
    [SerializeField] private TMP_Text codeText;
    private bool unLocked;
    private List<int> currentCode;

    private void Awake()
    {
      currentCode = new List<int>();
    }

    public void AddAndUpdate(int buttonNumber)
    {
      if(!unLocked)
      {
        currentCode.Add(buttonNumber);
        if(currentCode.Count >= safeCode.Count)
        {
          unLocked = CheckForCorrectCode();
          if(unLocked)
          {
            codeText.text = "Unlocked";
          } else {
            codeText.text = "Incorrect";
            currentCode = new List<int>();
            Invoke("ResetText", 1f);
          }
        } else {
          string code = "";
          foreach(int number in currentCode)
          {
            code += number.ToString();
          }
          codeText.text = code;
        }
      }
    }

    private bool CheckForCorrectCode()
    {
      for(int a = 0; a < safeCode.Count; a++)
      {
        if(safeCode[a] != currentCode[a])
        {
          return false;
        }
      }
      return true;
    }

    private void ResetText()
    {
      codeText.text = "";
    }
}
