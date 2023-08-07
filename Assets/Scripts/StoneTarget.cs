using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneTarget : MonoBehaviour
{
    private Renderer _renderer;
    // Start is called before the first frame update
    void Start()
    {
        _renderer = GetComponent<Renderer>();
    }

    private void OnMouseEnter()
    {
        _renderer.material.color = Color.cyan;
    }

    private void OnMouseOver()
    {
        _renderer.material.color = Color.red;

    }
}
