using UnityEngine;

public class Mover : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D _rigidBody;
    private bool _isMoveLeft;
    private bool _isMoveRight;
    private bool _isMoveUp;
    private bool _isMoveDown;
    private float _horizontal;
    private float _vetrical;

    private void FixedUpdate()
    {
        if (_isMoveDown || _isMoveUp)
            _rigidBody.velocity = new Vector2(0, _vetrical);
        if (_isMoveRight || _isMoveLeft)
            _rigidBody.velocity = new Vector2(_horizontal, 0);
    }

    public void Move(
        Directions direction, 
        float verticalSpeed, 
        float horizontalSpeed, 
        string trigger,
        TurningPoint point)
    {
        UpdateDirections(direction);
        _vetrical = verticalSpeed;
        _horizontal = horizontalSpeed;
        _animator.SetTrigger(trigger);
        if (point != null) transform.position = new Vector3(point.X, point.Y, 0);
    }
    
    public void UpdateDirections(Directions direction)
    {
        var moveCycle = GetCycleResult(direction);
        _isMoveLeft = moveCycle.Left;
        _isMoveRight = moveCycle.Right;
        _isMoveUp = moveCycle.Up;
        _isMoveDown = moveCycle.Down;
    }

    public (bool Left, bool Right, bool Up, bool Down) GetCycleResult(Directions dir)
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