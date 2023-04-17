using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[Serializable]
public class Powerup 
{
    [SerializeField]
    public string name;

    [SerializeField]
    public float duration;

    [SerializeField]
    public bool isOneTime;

    [SerializeField]
    public Sprite powerUpSprite;

    // used to apply the Powerup of the Powerup
    [SerializeField]
    public UnityEvent startAction;

    // used to remove the Powerup of the Powerup
    [SerializeField]
    public UnityEvent endAction;

    public void EndP()
    {
        if (endAction != null)
            endAction.Invoke();
    }

    public void StartP()
    {
        if (startAction != null)
            startAction.Invoke();
    }
}