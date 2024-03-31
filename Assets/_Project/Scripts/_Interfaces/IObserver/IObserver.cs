using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IObserver
{
    void PerformObserableAction(bool recievedVariable);
}
