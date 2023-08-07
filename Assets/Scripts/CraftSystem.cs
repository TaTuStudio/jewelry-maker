using System;
using System.Collections.Generic;
using UnityEngine;

public class CraftSystem : MonoBehaviour
{
    [SerializeField] private List<GameObject> steps;
    [SerializeField] private new Camera camera;
    [SerializeField] private List<Transform> cameraPos;
    [SerializeField] private List<Material> metalMaterials;
    [SerializeField] private List<Material> stoneMaterials;
    private void StepChange()
    {
        
    }

    private void Update()
    {
        var _gameObject = camera.gameObject;
        _gameObject.transform.position = cameraPos[1].position;
        _gameObject.transform.rotation = cameraPos[1].rotation;
        
    }
}
