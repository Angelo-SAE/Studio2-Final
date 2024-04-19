using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Scoreboard : MonoBehaviour
{
    [SerializeField] private TMP_Text scoreBoardText;
    [SerializeField] private PokerChipSet set;
    [SerializeField] private int sectionNumer;

    public void OnNotify()
    {
      UpdateScoreText();
    }

    private void UpdateScoreText()
    {
      scoreBoardText.text = set.sectionValues[sectionNumer].ToString();
    }
}
