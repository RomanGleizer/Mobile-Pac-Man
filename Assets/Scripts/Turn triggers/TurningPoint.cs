using UnityEngine;

public class TurningPoint : MonoBehaviour
{
    [SerializeField] private Directions[] _directions;

    public Directions[] Directions => _directions;

    public float X { get; private set; }

    public float Y { get; private set; }

    private void Start()
    {
        X = transform.position.x;
        Y = transform.position.y;
    }
}