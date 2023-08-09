using System;
using System.Collections.Generic;
using DG.Tweening;
using Lofelt.NiceVibrations;
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
    [SerializeField] private HapticClip[] clips;
    [SerializeField] private SoundEffectSO[] sounds;

    private RaycastHit targetHit;
    private Transform target;
    private int step;
    private int sparkle;
    private Transform lastTarget;
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
            nextStep.gameObject.SetActive(false);
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
                    if (lastTarget == target)
                    {
                        return;
                    }

                    if (target.CompareTag("stone"))
                    {
                        target.gameObject.GetComponent<Renderer>().material = necklaceSo.stoneMaterial;
                        target.gameObject.GetComponent<MeshFilter>().mesh = necklaceSo.stoneMesh;
                        HapticController.Play(clips[0]);
                        sounds[0].Play();
                        lastTarget = target;
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
                    target = targetHit.transform;
                    if (lastTarget == target)
                    {
                        return;
                    }
                    if (target.CompareTag("stone2"))
                    {
                        target.gameObject.GetComponent<Renderer>().material = necklaceSo.stoneMaterial;
                        HapticController.Play(clips[1]);
                        sounds[1].Play();
                        lastTarget = target;
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
                    if (lastTarget == target)
                    {
                        return;
                    }
                    if (target.CompareTag("sparkle"))
                    {
                        HapticController.Play(clips[2]);
                        sounds[2].Play();
                        sparkle++;
                        if (sparkle == 5)
                        {
                            necklaceSo.necklaceMetalMaterial.SetFloat("_Smoothness", 0.5f);
                            SetNecklaceMat();
                            nextStep.gameObject.SetActive(true);
                        }
                        target.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                        target.gameObject.GetComponent<SphereCollider>().enabled = false;
                        lastTarget = target;
                    }
                    if (target.CompareTag("sparkle2"))
                    {
                        necklaceSo.medMetalMaterial.SetFloat("_Smoothness", 0.5f);
                        SetMedMat();
                        target.gameObject.transform.GetChild(0).gameObject.SetActive(true);
                        target.gameObject.GetComponent<SphereCollider>().enabled = false;
                        lastTarget = target;
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

    private void ChangeCamPos(int pos, bool anim = false)
    {
        if (!anim)
        {
            camera.transform.SetPositionAndRotation(cameraPos[pos].position, cameraPos[pos].rotation);
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
            drill.SetActive(false);
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
                nextStep.gameObject.SetActive(false);
                drill.SetActive(false);
                selectMaterial.DOAnchorPosY(-1100, 0.5f).SetEase(Ease.InBack);
                selectStone.DOAnchorPos(Vector2.zero, 0.5f).SetEase(Ease.OutBack);
                break;
            case 2:
                nextStep.gameObject.SetActive(false);
                selectStone.DOAnchorPosY(-1100, 0.5f).SetEase(Ease.InBack);
                selectMedMaterial.DOAnchorPos(Vector2.zero, 0.5f).SetEase(Ease.OutBack);
                medal.SetActive(true);
                necklace.SetActive(false);
                ChangeCamPos(2, true);
                break;
            case 3:
                nextStep.gameObject.SetActive(false);
                selectMedMaterial.DOAnchorPosY(-1100, 0.5f).SetEase(Ease.InBack);
                selectStone.DOAnchorPos(Vector2.zero, 0.5f).SetEase(Ease.OutBack);
                break;
            case 4:
                nextStep.gameObject.SetActive(false);
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
