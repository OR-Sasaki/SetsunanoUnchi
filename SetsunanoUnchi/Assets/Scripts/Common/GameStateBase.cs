using System;
using System.Collections;
using System.Xml.Schema;
using UnityEngine;

public abstract class GameStateBase<T> : MonoBehaviour where T : Enum
{
    public virtual void OnUIEvent(UIBase ui, string message) { }

    public virtual void OnStateClose() { }
}