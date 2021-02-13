using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Barca : MonoBehaviour
{
    private int stato;
    private bool attraccata; //diventa falsa alla partenza
    private bool daFilippo; //diventa falsa alla seconda partenza
    private bool firstTime; //serve a cambiare stato solo una volta da 1 a 2
    private bool firstTime2; //serve a cambiare stato solo una volta da 3 a 4


    void Start()
    {
        attraccata = true;
        firstTime = true;
        daFilippo = true;
        firstTime2 = true;
    }


    void Update()
    {
        stato = VirgilioIracondi.state;
        if (stato == 1 && attraccata)
        {
            attraccata = false;

            //prima remata
            transform.DOMoveX(513.35f, 35).SetEase(Ease.InOutSine);
      
        }

        //cambio stato 1->2 
        if (stato == 1 && transform.position.x < 515 && firstTime)
        {
            firstTime = false;
            VirgilioIracondi.state = 2;
        }



        if (stato == 3 && daFilippo)
        {
            daFilippo = false;

            //seconda remata
            transform.DOMoveX(322.4f, 45).SetEase(Ease.InOutSine);

        }

        //cambio stato 3->4
        //per adesso non lo facciamo perché altrimenti c'è il rischio di balzare il dialogo con virgilio stato 3, che serve per la pergamena.
        /* if (stato == 3 && transform.position.x < 325 && firstTime2)
        {
            firstTime2 = false;
            VirgilioIracondi.state = 4;
        }
        */


    }
}
