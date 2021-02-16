using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


public class Anastasio : Interactable
{
    private float distance;

    public GameObject DialogueName;
    public GameObject DialogueText;
    public GameObject ContinueText;
    public GameObject DanteController;
    AudioSource _feedback;


    // Start is called before the first frame update
    void Start()
    {
        _feedback = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = InteractionManager.distance;
    }


    public override void Interact(GameObject caller)
    {
        if (VirgilioEretici.state == 0 || VirgilioEretici.state == 2)
        {
            //Set State 0-->1/2-->3
            VirgilioEretici.state++;

           

            //Lock Interaction
            InteractionManager.active = false;

            //Lock rotation and movement
            MouseLook.active = false;
            PlayerMovement.active = false;


            //Bush Sound




            DialogueName.GetComponent<Text>().text = "ISCRIZIONE";

            DialogueText.GetComponent<Text>().text = "Custodisco papa Anastasio, che fu sviato dalla retta strada da Fotino.";

            ContinueText.GetComponent<Text>().text = "Clicca per continuare.";




            //Left Click to Continue

            StartCoroutine(WaitForLeftClick());



            //StartCoroutine(ResetChat());
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

                //feedback
                _feedback.Play();

                yield break;
            }

            yield return null;
        }
    }

    public override bool ObtainType()
    {
        return true;
    }
}