using System;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private Tower _tower;

    private void OnEnable()
    {
        _tower.FinishReached += OnFinishReached;
    }

    private void OnDisable()
    {
        _tower.FinishReached -= OnFinishReached;
    }

    private void OnFinishReached()
    {
        Debug.LogWarning("Tower is cleared !");
    }
}
