using UnityEngine;

[RequireComponent(typeof(Mover))]
public class PacManMover : MonoBehaviour
{
    public const float PacManSpeed = 1.2f;

    private Mover _pacManMover;

    public void SwitchLeftEventDataDown() 
        => _pacManMover.Move(Directions.Left, 0, -PacManSpeed, MoveTriggers.LeftTrigger);

    public void SwitchRightEventDataDown() 
        => _pacManMover.Move(Directions.Right, 0, PacManSpeed, MoveTriggers.RightTrigger);

    public void SwitchUpEventDataDown() 
        => _pacManMover.Move(Directions.Up, PacManSpeed, 0, MoveTriggers.UpTrigger);

    public void SwitchDownEventDataDown() 
        => _pacManMover.Move(Directions.Down, -PacManSpeed, 0, MoveTriggers.DownTrigger);

    public void Initialize()
    {
        _pacManMover = GetComponent<Mover>();
        _pacManMover.Initialize();
    }
}