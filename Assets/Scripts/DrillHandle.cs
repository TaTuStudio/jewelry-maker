using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrillHandle : MonoBehaviour
{
    private Vector3 mousePos;
    private bool turnOnEffect;
    [SerializeField] private GameObject effect;
    
    private Vector3 GetMousePos()
    {
        return Camera.main.WorldToScreenPoint(transform.position);
    }

    private void OnMouseDown()
    {
        mousePos = Input.mousePosition - GetMousePos();
    }

    private void OnMouseDrag()
    {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition - mousePos);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("stone") && !turnOnEffect)
        {
            turnOnEffect = true;
            effect.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (turnOnEffect)
        {
            turnOnEffect = false;
            effect.gameObject.SetActive(false);
        }
    }
}
