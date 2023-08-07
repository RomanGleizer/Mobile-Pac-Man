using UnityEngine;

[RequireComponent(typeof(Mover))]
public class PacManMover : MonoBehaviour
{
    [SerializeField] private PacManDeathHandler _deathHandler;

    private Mover _mover;
    private Corridor _corridor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out TurningPoint point))
        {
            _mover.UpdateTurningPoint(point);

            if (_corridor == null) return;
            _corridor.SwitchMoveButtons(true);
            _corridor = null;
        }

        if (collision.TryGetComponent(out Corridor corridor))
        {
            _mover.UpdateTurningPoint(null);
            _corridor = corridor;
            _corridor.SwitchMoveButtons(false);
        }

        if (collision.GetComponent<EnemyMover>())
        {
            foreach (var enemy in _deathHandler.Enemies)
            {
                enemy.transform.position = enemy.RebornPosition;
                enemy.Moves[Directions.Left].Invoke();
            }

            _deathHandler.GetDamage();
        }
    }

    public void Initialize()
    {
        _mover = GetComponent<Mover>();
        _mover.Initialize();
    }
}