using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletSprite : MonoBehaviour
{
    [SerializeField] private GameObject tabletSprite;
    [SerializeField] private Mode mode;

    public void OnNotify()
    {
      TurnOnOffSprite();
    }

    private void TurnOnOffSprite()
    {
      if(mode.mode3D)
      {
        tabletSprite.SetActive(false);
      } else {
        tabletSprite.SetActive(true);
      }
    }
}
