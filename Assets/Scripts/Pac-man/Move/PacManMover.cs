using UnityEngine;

public class PacManMover : MonoBehaviour
{
    [SerializeField] private float _speed;

    private Rigidbody2D _rb;
    private float _horizontalDistance;
    private float _verticalDistance;

    public bool IsMovingLeft { get; private set; }

    public bool IsMovingRight { get; private set; }

    public bool IsMovingUp { get; private set; }

    public bool IsMovingDown { get; private set; }

    private void Update()
    {
        if (IsMovingLeft) _horizontalDistance = -_speed;
        if (IsMovingDown) _verticalDistance = -_speed;
        if (IsMovingRight) _horizontalDistance = _speed;
        if (IsMovingUp) _verticalDistance = _speed;
    }

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
    }

    public void SwitchRightEventDataDown()
    {
        IsMovingRight = true;
        IsMovingLeft = IsMovingUp = IsMovingDown = false;
    }

    public void SwitchUpEventDataDown()
    {
        IsMovingUp = true;
        IsMovingLeft = IsMovingRight = IsMovingDown = false;
    }

    public void SwitchDownEventDataDown()
    {
        IsMovingDown = true;
        IsMovingLeft = IsMovingUp = IsMovingRight = false;
    }

    /* Method for GameInitializer.cs */

    public void InitializeRigidbody() => _rb = GetComponent<Rigidbody2D>();
}