using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PublisherDispatcher : MonoBehaviour, ISubscriber
{
    [SerializeField] private Publisher publisher;
    [SerializeField] private UnityEvent onNotify;

    private void Start()
    {
      publisher.AddSubscriber(this);
    }

    public void OnNotify()
    {
      onNotify.Invoke();
    }
}
