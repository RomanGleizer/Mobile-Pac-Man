using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private PacManMover _pacMan;
    [SerializeField] private EnemyMover[] _enemies;

    private void Awake()
    {
        _pacMan.Initialize();
        foreach (var e in _enemies)
            e.Initialize();
    }
}