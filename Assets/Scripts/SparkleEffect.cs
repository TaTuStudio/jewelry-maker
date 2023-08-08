using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkleEffect : MonoBehaviour
{
    private SphereCollider sparkleCollider;

    private void Start()
    {
        sparkleCollider = GetComponent<SphereCollider>();
    }
    private void OnEnable()
    {
        CraftSystem.StepEnter += StartStep;
    }


    private void OnDestroy()
    {
        CraftSystem.StepEnter -= StartStep;
    }


    private void StartStep(int step)
    {
        sparkleCollider.enabled = step == 4;
    }
}
