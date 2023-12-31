using UnityEngine;

public class Mover : MonoBehaviour
{
    private const float Speed = 1.2f;

    private Animator _animator;
    private Rigidbody2D _rigidBody;
    private TurningPoint _turningPoint;
    private bool _isMoveLeft;
    private bool _isMoveRight;
    private bool _isMoveUp;
    private bool _isMoveDown;
    private float _horizontal;
    private float _vetrical;

    private void FixedUpdate()
    {
        if (_isMoveDown || _isMoveUp) _rigidBody.velocity = new Vector2(0, _vetrical);
        if (_isMoveRight || _isMoveLeft) _rigidBody.velocity = new Vector2(_horizontal, 0);
    }

    public void MoveRight() => HandMove(Directions.Left, Speed, MoveTriggers.RightTrigger);

    public void MoveLeft() => HandMove(Directions.Right, -Speed, MoveTriggers.LeftTrigger);

    public void MoveUp() => HandMove(Directions.Up, Speed, MoveTriggers.UpTrigger);

    public void MoveDown() => HandMove(Directions.Down, -Speed, MoveTriggers.DownTrigger);

    public void UpdateTurningPoint(TurningPoint point) => _turningPoint = point;

    private void HandMove(Directions direction, float speed, string trigger)
    {
        UpdateDirections(direction);

        if (direction is Directions.Left || direction is Directions.Right) _horizontal = speed;
        else _vetrical = speed;

        if (gameObject.activeSelf) _animator.SetTrigger(trigger);

        if (_turningPoint != null)
            transform.position = new Vector3(_turningPoint.X, _turningPoint.Y, 0);
    }

    private void UpdateDirections(Directions direction)
    {
        var moveCycle = GetCycleResult(direction);
        _isMoveLeft = moveCycle.Left;
        _isMoveRight = moveCycle.Right;
        _isMoveUp = moveCycle.Up;
        _isMoveDown = moveCycle.Down;
    }

    private (bool Left, bool Right, bool Up, bool Down) GetCycleResult(Directions dir)
    {
        switch (dir)
        {
            case Directions.Left: return (true, false, false, false);
            case Directions.Right: return (false, true, false, false);
            case Directions.Up: return (false, false, true, false);
            case Directions.Down: return (false, false, false, true);
            default: return (false, false, false, false);
        }
    }

    public void Initialize()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
}