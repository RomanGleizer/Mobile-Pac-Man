using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private PacManMover[] _pacMen;
    [SerializeField] private EnemyMover[] _enemies;

    private void Awake()
    {
        foreach (var p in _pacMen)
            p.Initialize();
        foreach (var e in _enemies)
            e.Initialize();
    }
}