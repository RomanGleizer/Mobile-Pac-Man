using UnityEngine;
using System.Threading.Tasks;

[RequireComponent(typeof(Mover))]
public class EnemyMover : MonoBehaviour
{
    public const float EnemySpeed = 1f;

    private Mover _enemyMover;
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
                _enemyMover.Move(Directions.Left, 0, -EnemySpeed, MoveTriggers.LeftTrigger, _point);
                break;
            case Directions.Right:
                _enemyMover.Move(Directions.Right, 0, EnemySpeed, MoveTriggers.RightTrigger, _point);
                break;
            case Directions.Up:
                _enemyMover.Move(Directions.Up, EnemySpeed, 0, MoveTriggers.UpTrigger, _point);
                break;
            case Directions.Down:
                _enemyMover.Move(Directions.Down, -EnemySpeed, 0, MoveTriggers.DownTrigger, _point);
                break;
            default: break;
        }
    }

    public void Initialize()
    {
        _enemyMover = GetComponent<Mover>();
        _enemyMover.Initialize();
    }
}