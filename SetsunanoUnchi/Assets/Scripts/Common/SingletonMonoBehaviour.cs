using System;
using Photon;
using UnityEngine;
using MonoBehaviour = UnityEngine.MonoBehaviour;

public abstract class SingletonMonoBehaviour<T> : MonoBehaviour where T : MonoBehaviour
{
    private static T _instance;
    public static T I
    {
        get
        {
            if (_instance == null)
            {
                Type t = typeof(T);

                _instance = (T)FindObjectOfType(t);
                if (_instance == null)
                {
                    Debug.LogError(t + " をアタッチしているGameObjectはありません");
                }
            }

            return _instance;
        }
    }

    protected virtual void Awake ()
    {
        if (this != I)
        {
            Destroy(this.gameObject);
            
            Debug.LogError(
                typeof(T) +
                " は既に他のGameObjectにアタッチされているため、コンポーネントを破棄しました." +
                " アタッチされているGameObjectは " + I.gameObject.name + " です.");
            return;
        }

        DontDestroyOnLoad(this.gameObject);
    }

}