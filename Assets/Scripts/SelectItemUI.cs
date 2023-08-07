using UnityEngine;

public class SelectItemUI : MonoBehaviour
{
    [SerializeField] private CraftSystem _craftSystem;
    public void SelectNecklace()
    {
        ChangeState();   
        _craftSystem.SelectNecklace();
    }

    public void SelectTeeth()
    {
        ChangeState();
        _craftSystem.SelectTeeth();
    }

    private void ChangeState() => GameManager.Instance.ChangeState(GameManager.GameState.CraftState);
}
