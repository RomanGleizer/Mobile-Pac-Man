using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class PacManDeathHandler : MonoBehaviour
{
    [SerializeField] private PacManMover[] _reservePacMen;
    [SerializeField] private EnemyMover[] _enemies;
    [SerializeField] private Image[] _pacManAttempts;
    [SerializeField] private int _attemptsNumber;
    [SerializeField] private MenuHandler _menuHandler;
    [SerializeField] private Menu _deathMenu;

    public EnemyMover[] Enemies => _enemies;

    public void GetDamage()
    {
        _attemptsNumber--;
        if (_attemptsNumber == 0) Death();
        else Reborn();
    }

    private void Death()
    {
        _menuHandler.SwitchMenuState(_deathMenu);
        RemoveCurrentPacMan();
    }

    private void Reborn()
    {
        FreezeGame();
        RemoveCurrentPacMan();
        _reservePacMen[_attemptsNumber - 1].gameObject.SetActive(true);
    }

    private async void FreezeGame()
    {
        Time.timeScale = 0.0f;
        await Task.Delay(2000);
        Time.timeScale = 1.0f;
    }

    private void RemoveCurrentPacMan()
    {
        _pacManAttempts[_attemptsNumber].gameObject.SetActive(false);
        _reservePacMen[_attemptsNumber].gameObject.SetActive(false);
    }
}