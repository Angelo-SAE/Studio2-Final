using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserver
{
    void AddSelfToObservable();
    void PerformObserableAction(bool recievedVariable);
}
