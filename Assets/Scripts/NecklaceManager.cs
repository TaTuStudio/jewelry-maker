using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class NecklaceManager : MonoBehaviour
{
    [SerializeField] private Renderer[] stoneMats;
    [SerializeField] private Renderer[] metalMats;
    [SerializeField] private Necklace necklaceSo;

    private void Awake()
    {
        OnGameStateChanged += GameManagerOnGameStateChanged;
    }

    private void OnDestroy()
    {
        OnGameStateChanged -= GameManagerOnGameStateChanged;
    }
    private void GameManagerOnGameStateChanged(GameState state)
    {
        if (state == GameState.StartGame)
        {
            foreach (var stoneMat in stoneMats)
            {
                stoneMat.material = necklaceSo.stoneNoneMaterial;
            }

            foreach (var metalMat in metalMats)
            {
                metalMat.material = necklaceSo.metalNoneMaterial;
            }

            foreach (var mat in necklaceSo.metalMaterials)
            {
                mat.SetFloat("_Smoothness", 0.1f);
            }
        }
    }
}
