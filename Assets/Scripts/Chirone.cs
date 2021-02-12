using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


public class Chirone : Interactable
{
    private float distance;

    public GameObject DialogueName;
    public GameObject DialogueText;
    public GameObject ContinueText;
    public GameObject DanteController;
    AudioSource _feedback;
    private bool firstTime;

    // Start is called before the first frame update
    void Start()
    {
        _feedback = GetComponent<AudioSource>();
        firstTime = true;
    }

    // Update is called once per frame
    void Update()
    {
        distance = InteractionManager.distance;
        if (VirgilioViolenti.state == 4) {
            if (firstTime)
            {
                _feedback.Play();
                firstTime = false;
            }
        }
    }


    public override void Interact(GameObject caller)
    {

        if (VirgilioViolenti.state == 0)
        {
            //Set State 0-->1
            VirgilioViolenti.state++;

            //Lock Interaction
            InteractionManager.active = false;

            //Lock rotation and movement
            MouseLook.active = false;
            PlayerMovement.active = false;
            //this.transform.LookAt(new Vector3(DanteController.transform.position.x, this.transform.position.y, DanteController.transform.position.y));






            DialogueName.GetComponent<Text>().text = "CHIRONE";

            DialogueText.GetComponent<Text>().text = "A quale pena venite voi che scendete la china? Ditecelo, altrimenti scaglio una freccia.";

            ContinueText.GetComponent<Text>().text = "Clicca per continuare.";




            //Left Click to Continue

            StartCoroutine(Dialogue1());



            //StartCoroutine(ResetChat());
        }

    }

    IEnumerator Dialogue1()
    {
        yield return new WaitForSeconds(1f);
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                DialogueText.GetComponent<Text>().text = "Compagni, vi siete accorti che quello dietro (Dante) muove ciò che tocca? I piedi dei morti, di solito, non fanno così.";
                StartCoroutine(Dialogue2());
                yield break;
            }

            yield return null;
        }
    }
    

    IEnumerator Dialogue2()
    {
        yield return new WaitForSeconds(1f);
        while (true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                DialogueText.GetComponent<Text>().text = "Nesso, torna indietro, e guidali, e fa' spostare quelli che vi ostacolano.";
                StartCoroutine(WaitForLeftClick());
                yield break;
            }

            yield return null;
        }
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
                _feedback.Play();
                yield break;
            }

            yield return null;
        }
    }


}