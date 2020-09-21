using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneFader : SingletonMonoBehaviour<SceneFader> 
{
    enum State
    {
        Idle,
        // 自分のオブジェクト基準で
        FadeIn,
        FadeOut,
    }

    private State _state = State.Idle;
    [SerializeField] private Image _image;
    [SerializeField] private float _fadeSpeed = 0.05f;

    private void Update()
    {
        var color = _image.color;
        
        switch (_state)
        {
            case State.FadeIn:
                color.a += _fadeSpeed;
                if (color.a <= 0)
                {
                    color.a = 0;
                    _state = State.Idle;
                }
                break;
            case State.FadeOut:
                color.a -= _fadeSpeed;
                if (color.a >= 1)
                {
                    color.a = 1;
                    _state = State.Idle;
                }
                break;
        }

        _image.color = color;
    }

    public void FadeOut()
    {
        _state = State.FadeOut;
    }

    public void FadeIn()
    {
        _state = State.FadeIn;
    }

    public void SetOnOff(bool flag)
    {
        var color = _image.color;
        color.a = flag ? 1 : 0;
        _image.color = color;
    }
}
