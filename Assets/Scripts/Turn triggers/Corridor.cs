using UnityEngine;
using UnityEngine.UI;

public class Corridor : MonoBehaviour
{
    [SerializeField] private Button[] _moveButtons;

    public void SwitchMoveButtons(bool state)
    {
        foreach (var button in _moveButtons)
            button.gameObject.SetActive(state);
    }
}