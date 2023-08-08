using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

[CreateAssetMenu]
public class Necklace : ScriptableObject
{
    public Material medMetalMaterial;
    public Material necklaceMetalMaterial;
    public Material stoneMaterial;
    public Material stoneNoneMaterial;
    public Material metalNoneMaterial;
    public Material[] metalMaterials;
    public Material[] stoneMaterials;

    public void SetStoneMat0() => stoneMaterial = stoneMaterials[0];
    public void SetStoneMat1() => stoneMaterial = stoneMaterials[1];
    public void SetStoneMat2() => stoneMaterial = stoneMaterials[2];
    public void SetStoneMat3() => stoneMaterial = stoneMaterials[3];
    public void SetStoneMat4() => stoneMaterial = stoneMaterials[4];
    public void SetMetalMat0() => necklaceMetalMaterial = metalMaterials[0];
    public void SetMetalMat1() => necklaceMetalMaterial = metalMaterials[1];
    public void SetMetalMat2() => necklaceMetalMaterial = metalMaterials[2];
    public void SetMetalMat3() => necklaceMetalMaterial = metalMaterials[3];
    public void SetMedMetalMat0() => medMetalMaterial = metalMaterials[0];
    public void SetMedMetalMat1() => medMetalMaterial = metalMaterials[1];
    public void SetMedMetalMat2() => medMetalMaterial = metalMaterials[2];
    public void SetMedMetalMat3() => medMetalMaterial = metalMaterials[3];

}
