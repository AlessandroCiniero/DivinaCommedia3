using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class CenauroCorridoreInverso : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence
        .Append(transform.DOMoveZ(transform.position.z + 500, 20).SetEase(Ease.Linear))
        .Append(transform.DORotate(new Vector3(0, 180, 0), 1))
        .Append(transform.DOMoveZ(transform.position.z, 17).SetEase(Ease.Linear))
        .Append(transform.DORotate(new Vector3(0, 0, 0), 1))
        .SetLoops(-1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
