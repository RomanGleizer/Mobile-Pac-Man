using UnityEngine;

public class PacManMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private const string LeftTrigger = "Move Left";
    private const string RightTrigger = "Move Right";
    private const string DownTrigger = "Move Down";
    private const string UpTrigger = "Move Up";

    private Rigidbody2D _rb;
    private Animator _animator;
    private float _horizontalDistance;
    private float _verticalDistance;

    public bool IsMovingLeft { get; private set; }

    public bool IsMovingRight { get; private set; }

    public bool IsMovingUp { get; private set; }

    public bool IsMovingDown { get; private set; }

    private void FixedUpdate()
    {
        if (IsMovingUp || IsMovingDown) _rb.velocity = new Vector2(0, _verticalDistance);
        if (IsMovingRight || IsMovingLeft) _rb.velocity = new Vector2(_horizontalDistance, 0);
    }

    /* Methods for the buttons that are used to move the Pac-Man */

    public void SwitchLeftEventDataDown()
    {
        IsMovingLeft = true;
        IsMovingRight = IsMovingUp = IsMovingDown = false;
        _horizontalDistance = -_speed;
        _animator.SetTrigger(LeftTrigger);
    }

    public void SwitchRightEventDataDown()
    {
        IsMovingRight = true;
        IsMovingLeft = IsMovingUp = IsMovingDown = false;
        _horizontalDistance = _speed;
        _animator.SetTrigger(RightTrigger);
    }

    public void SwitchUpEventDataDown()
    {
        IsMovingUp = true;
        IsMovingLeft = IsMovingRight = IsMovingDown = false;
        _verticalDistance = _speed;
        _animator.SetTrigger(UpTrigger);
    }

    public void SwitchDownEventDataDown()
    {
        IsMovingDown = true;
        IsMovingLeft = IsMovingUp = IsMovingRight = false;
        _verticalDistance = -_speed;
        _animator.SetTrigger(DownTrigger);
    }

    /* Method for GameInitializer.cs */

    public void Initialize()
    {
        _rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }
}