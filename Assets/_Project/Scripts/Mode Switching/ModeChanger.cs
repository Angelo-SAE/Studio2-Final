using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ModeChanger : MonoBehaviour, IObservable
{
    [SerializeField] private bool mode3D;
    private List<IObserver> observers = new List<IObserver>();

    private void Start()
    {
      NotifyObservers();
    }

    private void Update()
    {
      ChangeMode();
    }

    private void ChangeMode()
    {
      if(Input.GetButtonDown("ModeChange"))
      {
        if(mode3D)
        {
          mode3D = false;
          NotifyObservers();
        } else {
          mode3D = true;
          NotifyObservers();
        }
      }
    }

    public void ChangeMode2()
    {
      if(mode3D)
      {
        mode3D = false;
        NotifyObservers();
      } else {
        mode3D = true;
        NotifyObservers();
      }
    }

    public void AddObserver(IObserver observer)
    {
      observers.Add(observer);
    }

    public void NotifyObservers()
    {
      for(int a = observers.Count; a > 0; a--)
      {
        observers[a - 1].PerformObserableAction(mode3D);
      }
    }

}
