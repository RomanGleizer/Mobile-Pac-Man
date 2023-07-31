using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private PacManMover _pacMan;
    [SerializeField] private EnemyMover _enemy;

    private void Awake()
    {
        _pacMan.Initialize();
        _enemy.Initialize();
    }
}