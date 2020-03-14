using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CaretBlink : MonoBehaviour
{
    private Image _img;
    private float _t;
    
    private void Awake()
    {
        _img = GetComponent<Image>();
    }

    void Update()
    {
        _t += Time.deltaTime;

        if (_t >= 0.6f)
        {
            _t = 0f;

            _img.enabled = !_img.enabled;
        }
    }
}
