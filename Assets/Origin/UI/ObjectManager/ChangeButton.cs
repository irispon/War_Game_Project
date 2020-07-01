using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ChangeButton<T> : MonoBehaviour where T :System.Enum
{
    [SerializeField]
    protected T mode;

    public abstract void Change();
}
