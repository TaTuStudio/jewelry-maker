using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class CraftSystem : MonoBehaviour
{
    [SerializeField] private List<GameObject> steps;
    [SerializeField] private new Camera camera;
    [SerializeField] private Transform[] cameraPos;
    [SerializeField] private Material[] metalMaterials;
    [SerializeField] private Material[] stoneMaterials;
    [SerializeField] private GameObject necklace;
    [SerializeField] private GameObject medal;
    private RaycastHit targetHit;
    private Transform target;

    private void Start()
    {
        medal.transform.SetParent(necklace.transform);
    }

    private void StepChange()
    {
    }
    
    
    private void Update()
    {
        var _gameObject = camera.gameObject;
        _gameObject.transform.position = cameraPos[1].position;
        _gameObject.transform.rotation = cameraPos[1].rotation;

        var ray = camera.ScreenPointToRay(Input.mousePosition);
        if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out targetHit))
        {
            target = targetHit.transform;
            if (target.CompareTag("stone"))
            {
                target.gameObject.GetComponent<Renderer>().material = stoneMaterials[1];
            }
        }
    }
}
