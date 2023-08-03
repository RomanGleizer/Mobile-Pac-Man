using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Mover))]
public class PacManMover : MonoBehaviour
{
    [SerializeField] private PacManDeathHandler _deathHandler;
    [SerializeField] private float _speed;

    private Mover _mover;
    private TurningPoint _point;
    private Corridor _corridor;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out TurningPoint point))
        {
            _point = point;
            
            if (_corridor == null) return;
            _corridor.SwitchMoveButtons(true);
            _corridor = null;
        }

        if (collision.TryGetComponent(out Corridor corridor))
        {
            _point = null;
            _corridor = corridor;
            _corridor.SwitchMoveButtons(false);
        }

        if (collision.GetComponent<EnemyMover>()) _deathHandler.GetDamage();
    }

    public void SwitchLeftEventDataDown()
        => _mover.HandMove(Directions.Left, 0, -_speed, MoveTriggers.LeftTrigger, _point);

    public void SwitchRightEventDataDown() 
        => _mover.HandMove(Directions.Right, 0, _speed, MoveTriggers.RightTrigger, _point);

    public void SwitchUpEventDataDown() 
        => _mover.HandMove(Directions.Up, _speed, 0, MoveTriggers.UpTrigger, _point);

    public void SwitchDownEventDataDown() 
        => _mover.HandMove(Directions.Down, -_speed, 0, MoveTriggers.DownTrigger, _point);

    public void Initialize()
    {
        _mover = GetComponent<Mover>();
        _mover.Initialize();
    }
}