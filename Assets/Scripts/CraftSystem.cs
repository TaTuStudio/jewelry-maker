using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using static GameManager;

public class CraftSystem : MonoBehaviour
{
    public delegate void OnStepStart(int step);
    public static event OnStepStart StepEnter;

    [SerializeField] private new Camera camera;
    [SerializeField] private Transform[] cameraPos;
    [SerializeField] private GameObject necklace;
    [SerializeField] private Renderer necklaceMat;
    [SerializeField] private GameObject medal;
    [SerializeField] private Renderer medalMat;
    [SerializeField] private Necklace necklaceSo;
    [SerializeField] private GameObject drill;
    [SerializeField] private RectTransform selectMaterial;
    [SerializeField] private RectTransform selectMedMaterial;
    [SerializeField] private RectTransform selectStone;
    [SerializeField] private Button nextStep;
    [SerializeField] private NecklaceManager necklaceManager;
    
    private RaycastHit targetHit;
    private Transform target;
    private int step;
    private int sparkle;
    private void Awake()
    {
        nextStep.onClick.AddListener(NextStep);
        OnGameStateChanged += GameManagerOnGameStateChanged;
    }

    private void OnDestroy()
    {
        OnGameStateChanged -= GameManagerOnGameStateChanged;
    }

    private void GameManagerOnGameStateChanged(GameState state)
    {
        if (state == GameState.CraftState)
        {
            sparkle = 0;
            step = 0;
            StepEnter?.Invoke(step);
        }
    }
    
    private void Update()
    {
        switch (step)
        {
            case 1:
            {
                var ray = camera.ScreenPointToRay(Input.mousePosition);
                if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out targetHit))
                {
                    target = targetHit.transform;
                    if (target.CompareTag("stone"))
                    {
                        target.gameObject.GetComponent<Renderer>().material = necklaceSo.stoneMaterial;
                        //target.gameObject.GetComponent<MeshFilter>().mesh = necklaceSo.stoneMesh;

                    }
                }
                break;
            }
            case 3:
            {
                var ray = camera.ScreenPointToRay(Input.mousePosition);
                if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out targetHit))
                {
                    target = targetHit.transform;
                    if (target.CompareTag("stone2"))
                    {
                        target.gameObject.GetComponent<Renderer>().material = necklaceSo.stoneMaterial;
                    }
                }
                break;
            }
            case 4:
            {
                var ray = camera.ScreenPointToRay(Input.mousePosition);
                if (!EventSystem.current.IsPointerOverGameObject() && Physics.Raycast(ray, out targetHit))
                {
                    target = targetHit.transform;
                    if (target.CompareTag("sparkle"))
                    {
                        sparkle++;
                        if (sparkle == 5)
                        {
                            necklaceSo.necklaceMetalMaterial.SetFloat("_Smoothness", 0.5f);
                            SetNecklaceMat();
                        }
                        target.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                        target.gameObject.GetComponent<SphereCollider>().enabled = false;
                    }
                    if (target.CompareTag("sparkle2"))
                    {
                        necklaceSo.medMetalMaterial.SetFloat("_Smoothness", 0.5f);
                        SetMedMat();
                        target.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                        target.gameObject.GetComponent<SphereCollider>().enabled = false;
                    }
                }
                break;
            }
        }
    }

    public void SelectNecklace()
    {
        ChangeCamPos(1);
        medal.SetActive(false);
        selectMaterial.DOAnchorPos(Vector2.zero, 0.5f).SetEase(Ease.InBack);
    }

    private void ChangeCamPos(int pos, bool animation = false)
    {
        if (!animation)
        {
            camera.transform.position = cameraPos[pos].position;
            camera.transform.rotation = cameraPos[pos].rotation;
        }
        else
        {
            camera.transform.DOLocalMove(cameraPos[pos].position, 1f).SetEase(Ease.OutQuint);
        }
    }

    public void SetNecklaceMat()
    {
        necklaceMat.material = necklaceSo.necklaceMetalMaterial;
    }
    public void SetMedMat()
    {
        medalMat.material = necklaceSo.medMetalMaterial;
    }


    private void NextStep()
    {
        if (step > 4)
        {
            GameManager.Instance.ChangeState(GameState.EndGame);
            ChangeCamPos(0);
            GameManager.Instance.ChangeState(GameState.StartGame);
            return;
        }
        
        step++;
        StepEnter?.Invoke(step);
        switch (step)
        {
            case 1:
                drill.SetActive(false);
                selectMaterial.DOAnchorPosY(-1100, 0.5f).SetEase(Ease.InBack);
                selectStone.DOAnchorPos(Vector2.zero, 0.5f).SetEase(Ease.OutBack);
                break;
            case 2:
                selectStone.DOAnchorPosY(-1100, 0.5f).SetEase(Ease.InBack);
                selectMedMaterial.DOAnchorPos(Vector2.zero, 0.5f).SetEase(Ease.OutBack);
                medal.SetActive(true);
                necklace.SetActive(false);
                ChangeCamPos(2, true);
                break;
            case 3:
                selectMedMaterial.DOAnchorPosY(-1100, 0.5f).SetEase(Ease.InBack);
                selectStone.DOAnchorPos(Vector2.zero, 0.5f).SetEase(Ease.OutBack);
                break;
            case 4:
                selectStone.DOAnchorPosY(-1100, 0.5f).SetEase(Ease.InBack);
                necklace.SetActive(true);
                ChangeCamPos(1, true);
                drill.SetActive(true);
                break;
        }
    }
    public void SelectTeeth()
    {
        
    }
}
