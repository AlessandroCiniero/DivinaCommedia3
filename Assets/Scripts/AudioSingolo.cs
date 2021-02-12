using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioSingolo : MonoBehaviour
{
    AudioSource _audio;
    bool _souna;

    void Start()
    {
        _audio = GetComponent<AudioSource>();
        _souna = false;
    }

   
    void Update()
    {
        
    }
}
