using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SparkleEffect : MonoBehaviour
{
    private SphereCollider sparkleCollider;
    private GameObject sparkleParticle;
    private void Start()
    {
        sparkleCollider = GetComponent<SphereCollider>();
        sparkleParticle = gameObject.transform.GetChild(0).gameObject;
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
        if (step == 0)
        {
            sparkleParticle.SetActive(false);
        }
    }
}
