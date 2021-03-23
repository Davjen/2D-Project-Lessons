using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static EventManager current;
    // Start is called before the first frame update

    private void Awake()
    {
        current = this;
    }

    public event Action onFalling;
    public event Action onComplete;
    public void OnFalling()
    {
        if (onFalling != null)
            onFalling();
    }
    public void OnComplete()
    {
        if (onComplete != null)
            onComplete();
    }
}
