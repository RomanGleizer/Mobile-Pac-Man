using UnityEngine;

[RequireComponent(typeof(Mover))]
public class EnemyMover : MonoBehaviour
{
    public const float EnemySpeed = 1f;

    private Mover _enemyMover;
    private Directions[] _directions;

    private void Start()
    {
        // _enemyMover.Move(Directions.Up, EnemySpeed, 0, MoveTriggers.DownTrigger);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<TurningPoint>())
        {
            var y = collision.GetComponent<TurningPoint>().Y;
            var randomDirection = _directions[Random.Range(0, _directions.Length)];
            if (transform.position.y >= y - 0.1f || transform.position.y <= y + 0.1f)
                ChangeDirectionalPath(randomDirection);
        }
    }

    private void ChangeDirectionalPath(Directions dir)
    {
        switch (dir)
        {
            case Directions.Left:
                _enemyMover.Move(Directions.Left, 0, -EnemySpeed, MoveTriggers.LeftTrigger);
                break;
            case Directions.Right:
                _enemyMover.Move(Directions.Right, 0, EnemySpeed, MoveTriggers.RightTrigger);
                break;
            case Directions.Up:
                _enemyMover.Move(Directions.Up, EnemySpeed, 0, MoveTriggers.UpTrigger);
                break;
            case Directions.Down:
                _enemyMover.Move(Directions.Down, -EnemySpeed, 0, MoveTriggers.DownTrigger);
                break;
            default: break;
        }
    }

    public void Initialize()
    {
        _enemyMover = GetComponent<Mover>();
        _enemyMover.Initialize();
        _directions = new[] { Directions.Left, Directions.Right, Directions.Up, Directions.Down };
    }
}