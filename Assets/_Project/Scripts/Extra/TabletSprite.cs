using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TabletSprite : MonoBehaviour, IObserver
{
    [SerializeField] private ModeChanger observable;
    [SerializeField] private GameObject tabletSprite;
    private bool mode3D;

    private void Awake()
    {
      AddSelfToObservable();
    }

    public void AddSelfToObservable()
    {
      observable.AddObserver(this);
    }

    public void PerformObserableAction(bool recievedVariable)
    {
      mode3D = recievedVariable;
      TurnOnOffSprite();
    }

    private void TurnOnOffSprite()
    {
      if(mode3D)
      {
        tabletSprite.SetActive(false);
      } else {
        tabletSprite.SetActive(true);
      }
    }
}
