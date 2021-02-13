﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


public class VirgilioIracondi : Interactable
{
    private float distance;
    public static int state = 0;
    public GameObject DialogueName;
    public GameObject DialogueText;
    public GameObject ContinueText;
    public GameObject DanteController;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        distance = InteractionManager.distance;
    }


    public override void Interact(GameObject caller)
    {
        //Lock Interaction
        InteractionManager.active = false;

        //Lock rotation and movement
        MouseLook.active = false;
        PlayerMovement.active = false;

        //Set animation rotation and movement

        this.GetComponent<Animator>().Play("Idle");
        this.GetComponent<NavMeshAgent>().enabled = false;
        this.GetComponent<Movimento>().enabled = false;


        //this.transform.LookAt(new Vector3(DanteController.transform.position.x, this.transform.position.y, DanteController.transform.position.y));

        if (state == 0) //bisogna interagire con  Flegias
        {
            DialogueName.GetComponent<Text>().text = "VIRGILIO";

            DialogueText.GetComponent<Text>().text = "Finalmente ti sei ridestato, Dante. Continueremo il nostro viaggio sulla barca di Flegiàs, per attraversare la palude Stige. Interagisci con lui quando sei pronto a salpare. Premi E per visualizzare la tua pergamena. Ricordati che potremo accedere al cerchio successivo solo quando avrai trovato tutti i versi mancanti. Li completerai parlando con i dannati.";

            ContinueText.GetComponent<Text>().text = "Clicca per continuare.";
        }

        //state 1 

        if (state == 1) //interagito con flegias parte la barca e si ferma quando si trova filippo argenti
        {
            DialogueName.GetComponent<Text>().text = "VIRGILIO";

            DialogueText.GetComponent<Text>().text = "Questa barca ci porterà sull'altra sponda dello stige.";

            ContinueText.GetComponent<Text>().text = "Clicca per continuare.";
        }

        //state 2

        if (state == 2) //barca ferma bisogna parlare con filippo argenti
        {
            DialogueName.GetComponent<Text>().text = "VIRGILIO";

            DialogueText.GetComponent<Text>().text = "Parla con l'anima di Filippo Argenti.";

            ContinueText.GetComponent<Text>().text = "Clicca per continuare.";
        }

        //state 3

        if (state == 3) //parlato con filippo argenti le anima si affollano su di lui e la barca riparte
        {
            DialogueName.GetComponent<Text>().text = "VIRGILIO";

            DialogueText.GetComponent<Text>().text = "Ormai, figliuolo, si avvicina la città chiamata Dite, coi suoi afflitti abitanti, col grande stuolo di diavoli.";

            ContinueText.GetComponent<Text>().text = "Clicca per continuare.";
        }


        //state 4

        if (state == 4) //la barca si è fermata e dante di trova sulla spiaggia
        {
            DialogueName.GetComponent<Text>().text = "VIRGILIO";

            DialogueText.GetComponent<Text>().text = "Ecco la città di Dite!";

            ContinueText.GetComponent<Text>().text = "Clicca per continuare.";
        }



        //Left Click to Continue

        StartCoroutine(WaitForLeftClick());



        //StartCoroutine(ResetChat());
    }


    IEnumerator WaitForLeftClick()
    {
        yield return new WaitForSeconds(1f);
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                DialogueName.GetComponent<Text>().text = "";
                DialogueText.GetComponent<Text>().text = "";
                ContinueText.GetComponent<Text>().text = "";

                InteractionManager.active = true;
                MouseLook.active = true;
                PlayerMovement.active = true;

                //Reset animation and movement
                //this.GetComponent<Animator>().Play("Standard Walk");
                this.GetComponent<NavMeshAgent>().enabled = true;
                this.GetComponent<Movimento>().enabled = true;

                yield break;
            }

            yield return null;
        }
    }
}