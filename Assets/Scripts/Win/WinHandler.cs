using UnityEngine;

public class WinHandler : MonoBehaviour
{
    [SerializeField] private Menu _winMenu;

    public void ShowWinMenu()
    {
        gameObject.GetComponent<MenuHandler>().SwitchMenuState(_winMenu);
    }
}