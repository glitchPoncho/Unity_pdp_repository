using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Rotation : MonoBehaviour
{
    public Transform Tree;
    public float duration;
    //public float scaleValue;
    public Vector3 rotateAxis;
    public Ease ease;
    void Start()
    {
        Tree
            .DORotate(rotateAxis, duration)
            .SetEase(ease)
            .SetLoops(-1, LoopType.Yoyo);
    }
}
