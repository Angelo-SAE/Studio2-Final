using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Publisher", menuName = "GeneralScriptableObjects/Publisher", order = 100)]
public class Publisher : ScriptableObject
{
  private List<ISubscriber> subscribers = new List<ISubscriber>();

  public void AddSubscriber(ISubscriber subscriber)
  {
    subscribers.Add(subscriber);
  }

  public void NotifySubscribers()
  {
    for(int a = subscribers.Count; a > 0; a--)
    {
      subscribers[a - 1].OnNotify();
    }
  }
}
