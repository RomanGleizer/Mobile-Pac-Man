using UnityEngine;

[RequireComponent(typeof(Mover))]
public class PacManMover : MonoBehaviour
{
    public const float PacManSpeed = 1.2f;

    private Mover _pacManMover;
    private TurningPoint _point;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out TurningPoint point)) _point = point;        
        if (collision.GetComponent<Corridor>()) _point = null;
    }

    public void SwitchLeftEventDataDown()
        => _pacManMover.Move(Directions.Left, 0, -PacManSpeed, MoveTriggers.LeftTrigger, _point);

    public void SwitchRightEventDataDown() 
        => _pacManMover.Move(Directions.Right, 0, PacManSpeed, MoveTriggers.RightTrigger, _point);

    public void SwitchUpEventDataDown() 
        => _pacManMover.Move(Directions.Up, PacManSpeed, 0, MoveTriggers.UpTrigger, _point);

    public void SwitchDownEventDataDown() 
        => _pacManMover.Move(Directions.Down, -PacManSpeed, 0, MoveTriggers.DownTrigger, _point);

    public void Initialize()
    {
        _pacManMover = GetComponent<Mover>();
        _pacManMover.Initialize();
    }
}