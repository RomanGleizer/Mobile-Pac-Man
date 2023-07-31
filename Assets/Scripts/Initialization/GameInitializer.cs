using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInitializer : MonoBehaviour
{
    [SerializeField] private PacManMover _pacMan;

    private void Awake()
    {
        _pacMan.Initialize();   
    }
}