using System;
using DG.Tweening;
using UnityEngine;

public class ObstacleRotator : MonoBehaviour
{
    [SerializeField] private float _animationDuration;
    private void Start()
    {
        transform.DORotate(new Vector3(0f, 360f, 0f), _animationDuration, RotateMode.FastBeyond360)
            .SetLoops(-1, LoopType.Yoyo);
    }
}
