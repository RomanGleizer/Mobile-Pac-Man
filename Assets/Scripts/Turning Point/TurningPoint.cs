using UnityEngine;

public class TurningPoint : MonoBehaviour
{
    [SerializeField] private float _y;
    [SerializeField] private Directions[] _directions;

    public Directions[] Directions => _directions;

    public float Y => _y;
}