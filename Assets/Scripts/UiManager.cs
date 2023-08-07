using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using static GameManager;

public class UiManager : MonoBehaviour
{
    [SerializeField] private Vector2[] offScreenPos;
    [SerializeField] private RectTransform homeUI;
    [SerializeField] private RectTransform selectItem;


    [SerializeField] private Button startBtn;

    private void Awake()
    {
        startBtn.onClick.AddListener(StartEvent);
        OnGameStateChanged += GameManagerOnGameStateChanged;
    }

    private void OnDestroy()
    {
        OnGameStateChanged -= GameManagerOnGameStateChanged;
    }

    private void GameManagerOnGameStateChanged(GameState state)
    {
        switch (state)
        {
            case GameState.StartGame:
                MoveToStartPos(homeUI);
                break;
            case GameState.CraftState:
                selectItem.DOAnchorPos(offScreenPos[1], 0.5f).SetEase(Ease.InQuad);
                break;
            case GameState.EndGame:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
    }

    private void MoveToStartPos(RectTransform rect)
    {
        rect.DOAnchorPos(Vector2.zero, 0.5f).SetEase(Ease.InQuad);
    }

    private void StartEvent()
    {
        homeUI.DOAnchorPos(offScreenPos[0], 0.5f).SetEase(Ease.InQuad);
        MoveToStartPos(selectItem);
    }
}
