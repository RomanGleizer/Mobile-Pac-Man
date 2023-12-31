using UnityEngine;
using System.Threading.Tasks;
using System.Collections.Generic;
using System;

[RequireComponent(typeof(Mover))]
public class EnemyMover : MonoBehaviour
{
    private Mover _mover;
    private TurningPoint _point;
    private Dictionary<Directions, Action> _moves;
    private Vector3 _rebornPosition;

    public Dictionary<Directions, Action> Moves => _moves;

    public Vector3 RebornPosition => _rebornPosition;

    private async void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out TurningPoint point))
        {
            _point = point;
            var randomDirection = _point.Directions[UnityEngine.Random.Range(0, _point.Directions.Length)];
            await Task.Delay(210);
            _moves[randomDirection].Invoke();
        }
    }

    public void Initialize()
    {
        _rebornPosition = new Vector3(transform.position.x - 0.53f, transform.position.y, 0);
        _mover = GetComponent<Mover>();
        _mover.Initialize();

        _moves = new Dictionary<Directions, Action>
        {
            { Directions.Right, _mover.MoveRight },
            { Directions.Left, _mover.MoveLeft },
            { Directions.Down, _mover.MoveDown },
            { Directions.Up, _mover.MoveUp },
        };
    }
}