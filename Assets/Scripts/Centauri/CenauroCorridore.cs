using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class CenauroCorridore : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(transform.DOMove(new Vector3(0, 0, -200), 7))
          .Append(transform.DORotate(new Vector3(0, 180, 0), 1))
          .Append(transform.DOMove(new Vector3(0, 0, 200), 7));
    }

    // Update is called once per frame
    void Update()
    {
     

    }
}
