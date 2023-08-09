using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DrillHandle : MonoBehaviour
{
    private Vector3 mousePos;
    private bool turnOnEffect;
    private Tween tw;
    [SerializeField] private GameObject effect;
    [SerializeField] private Transform drillHead;


    private void OnEnable()
    {
        tw = drillHead.DOLocalRotate(new Vector3(180f, 90f, 90f), 0.5f).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear);
    }

    private void OnDisable()
    {
        tw.Kill();
    }

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
