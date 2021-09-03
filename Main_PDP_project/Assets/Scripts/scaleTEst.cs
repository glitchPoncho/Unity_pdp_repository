using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class scaleTEst : MonoBehaviour
{
    public Transform Bush;
    public float duration;
    public float scaleValue;
    public Ease ease;
    void Start()
    {
        Bush
            .DOScale(scaleValue, duration)
            .SetEase(ease)
            .SetLoops(-1, LoopType.Yoyo);
    }
}