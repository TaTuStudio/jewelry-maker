using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using static GameManager;
public class StepProgressUI : MonoBehaviour
{
    [SerializeField] private Image[] listStepImage;
    [SerializeField] private Sprite startStepImage;
    [SerializeField] private Sprite finishStepImage;
    [SerializeField] private Sprite idleStepImage;
    [SerializeField] private RectTransform uiRect;
    
    private void Awake()
    {
        OnGameStateChanged += GameManagerOnGameStateChanged;
        CraftSystem.StepEnter += StartStep;
    }

    private void OnDestroy()
    {
        OnGameStateChanged -= GameManagerOnGameStateChanged;
        CraftSystem.StepEnter -= StartStep;
    }
    private void GameManagerOnGameStateChanged(GameState state)
    {
        switch (state)
        {
            case GameState.StartGame:
                uiRect.DOAnchorPosY(1100, 0.5f).SetEase(Ease.OutQuad);
                foreach (var image in listStepImage)
                {
                    image.sprite = idleStepImage;
                }  
                break;
            case GameState.CraftState:
                uiRect.DOAnchorPosY(0, 0.5f).SetEase(Ease.InQuad);
                break;
            case GameState.EndGame:
                uiRect.DOAnchorPosY(1100, 0.5f).SetEase(Ease.OutQuad);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
    }
    private void StartStep(int step)
    {
        if (step > 0)
        {
            listStepImage[step - 1].sprite = finishStepImage;
        }
        if (step <= 4)
        {
            listStepImage[step].sprite = startStepImage;
        }
    }

}
