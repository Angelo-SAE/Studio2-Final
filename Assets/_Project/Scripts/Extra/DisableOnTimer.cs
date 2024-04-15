using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableOnTimer : MonoBehaviour
{
    [SerializeField] private float waitTime;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(waitTime);
        gameObject.SetActive(false);
    }
}
