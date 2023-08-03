using UnityEngine;
using System.Threading.Tasks;

[RequireComponent(typeof(Mover))]
public class EnemyMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Mover _mover;
    private TurningPoint _point;

    private async void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out TurningPoint point))
        {
            _point = point;
            var randomDirection = _point.Directions[Random.Range(0, _point.Directions.Length)];
            await Task.Delay(250);
            ChangeDirectionalPath(randomDirection);
        }
    }

    private void ChangeDirectionalPath(Directions dir)
    {
        switch (dir)
        {
            case Directions.Left:
                _mover.HandMove(Directions.Left, 0, -_speed, MoveTriggers.LeftTrigger, _point);
                break;
            case Directions.Right:
                _mover.HandMove(Directions.Right, 0, _speed, MoveTriggers.RightTrigger, _point);
                break;
            case Directions.Up:
                _mover.HandMove(Directions.Up, _speed, 0, MoveTriggers.UpTrigger, _point);
                break;
            case Directions.Down:
                _mover.HandMove(Directions.Down, -_speed, 0, MoveTriggers.DownTrigger, _point);
                break;
            default: break;
        }
    }

    public void Initialize()
    {
        _mover = GetComponent<Mover>();
        _mover.Initialize();
    }
}