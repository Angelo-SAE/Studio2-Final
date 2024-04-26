using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWin : MonoBehaviour
{
    [SerializeField] private BoolObject hasTablet;

    public void OnNotify()
    {
      hasTablet.value = false;
    }
}
