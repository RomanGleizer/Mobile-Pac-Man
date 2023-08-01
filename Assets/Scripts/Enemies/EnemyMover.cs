using UnityEngine;
using System.Threading.Tasks;

[RequireComponent(typeof(Mover))]
public class EnemyMover : MonoBehaviour
{
    public const float EnemySpeed = 1f;

    private Mover _enemyMover;

    //private void Update()
    //{
    //    print(transform.position.y);
    //}

    private async void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<TurningPoint>())
        {
            var point = collision.GetComponent<TurningPoint>();
            var y = point.Y;
            var randomDirection = point.Directions[Random.Range(0, point.Directions.Length)];
            if (transform.position.y >= y - 0.1f || transform.position.y <= y + 0.1f)
            {
                await Task.Delay(250);
                ChangeDirectionalPath(randomDirection);
            }
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
    }
}