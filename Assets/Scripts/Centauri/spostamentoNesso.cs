﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class spostamentoNesso : MonoBehaviour
{
    public Animator _animator; 
    private int stato;
    private bool firstTime;
    private bool firstTime2;

    AudioSource _zoccoli;

    void Start()
    {
        _animator = GetComponent<Animator>();
        firstTime = true;
        firstTime2 = true;

        _zoccoli = GetComponent<AudioSource>();
    }

    void Update()
    {
        stato = VirgilioViolenti.state;

        //controllo animazione in base allo stato
        if (stato == 0 || stato == 1 || stato == 3 || stato == 5)
            _animator.SetBool("NessoCammina", false);
        else if (stato == 2 || stato == 4)
            _animator.SetBool("NessoCammina", true);

        //movimento di Nesso durante stato 2 
        if (stato == 2)
        {

            if (firstTime2)
            {
                _zoccoli.Play();

                firstTime2 = false;
            }

            transform.Translate(0, 0, Time.deltaTime * 25f);
            //cambio a stato 3
            if (transform.position.z < 1130)
            {
                VirgilioViolenti.state = 3;
                transform.DORotate(new Vector3(0, -270, 0), 1);
            }
        }

        //movimento durante stato 4
        if (stato == 4) 
        {
            if (firstTime)
            {
                transform.DORotate(new Vector3(0, -180, 0), 1);
                _zoccoli.Play();

                firstTime = false;
            }

            transform.Translate(0, 0, Time.deltaTime * 25f);
            //cambio a stato 5
            if (transform.position.z < 500)
                VirgilioViolenti.state = 5;
        }

        //zoccoli
        if (stato != 2 && stato != 4)
        {
            _zoccoli.Stop();

        }
    }
}
