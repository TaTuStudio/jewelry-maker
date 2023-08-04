using System;
using UnityEngine;

public class CraftSystem : MonoBehaviour
{
    public CraftStep Step;
    public static event Action<CraftStep> OnGameStateChanged;

    // Start is called before the first frame update
    private void Start()
    {
        ChangeStep(CraftStep.Step1);
    }

    private void ChangeStep(CraftStep newStep)
    {
        Step = newStep;
        switch (newStep)
        {
            case CraftStep.Step1:
                break;
            case CraftStep.Step2:
                break;
            case CraftStep.Step3:
                break;
            case CraftStep.Step4:
                break;
        }
        OnGameStateChanged?.Invoke(newStep);
    }
    public enum CraftStep
    {
        Step1,
        Step2,
        Step3,
        Step4
    }
}
